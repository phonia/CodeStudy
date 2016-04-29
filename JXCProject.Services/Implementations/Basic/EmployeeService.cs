using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JXCProject.Domain.Models;
using JXCProject.Services.CacheStorage;
using JXCProject.Services.Interfaces.Basic;
using JXCProject.Services.DTOs;
using JXCProject.Services.Mapping;

namespace JXCProject.Services.Implementations.Basic
{
    public class EmployeeService : IEmployeeService
    {
        IEmployeeRepository employeeRepository;
        IDepartmentRepository deptRepository;
        ICacheStorage cache;

        public EmployeeService(IEmployeeRepository employeeRepository, IDepartmentRepository deptRepository, ICacheStorage cache)
        {
            this.employeeRepository = employeeRepository;
            this.deptRepository = deptRepository;
            this.cache = cache;
        }

        public void AddEmployee(EmployeeDTO employeeDto)
        {
            employeeDto.ID = new Guid();
            employeeRepository.Add(employeeDto.ConvertToEmployee()); 
            employeeRepository.UnitOfWork.Commite();
        }
        
        public void RemoveEmployee(EmployeeDTO employeeDto)
        {
            employeeRepository.Remove(employeeDto.ConvertToEmployee());
            employeeRepository.UnitOfWork.Commite();
        }

        public IEnumerable<EmployeeDTO> GetPageData(int pageIndex, int pageCount, string departmentId, string employeeName, string orderText, bool ascending, out int recordCount)
        {
            recordCount = employeeRepository.GetByWhere(o => o.DeptId == departmentId && o.Name.Contains(employeeName), true).Count();
            var query= employeeRepository.GetAll(pageIndex, pageCount, o => o.DeptId == departmentId && o.Name.Contains(employeeName), orderText, ascending, true);
            return query.ConvertToEmployeeDtos();
        }

        public void ModifyEmployee(EmployeeDTO originalEmployeeDto, EmployeeDTO newEmployeeDto)
        {
            employeeRepository.Modify(originalEmployeeDto.ConvertToEmployee(), newEmployeeDto.ConvertToEmployee());
            employeeRepository.UnitOfWork.Commite();
        }

        public EmployeeDTO GetEmployeeById(Guid Id)
        {
            Employee employee;
            employee = cache.Retrieve<Employee>(Id.ToString());

            if (employee == null)
            {
                employee = employeeRepository.GetById(Id);
                cache.Add(Id.ToString(), employee);
            }

            return employee.ConvertToEmployeeDto();
        }
    }
}
