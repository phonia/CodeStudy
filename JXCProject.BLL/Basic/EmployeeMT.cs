using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JXCProject.BLL.Basic.IBLL;
using JXCProject.Domain.Models;
using JXCProject.BLL.CacheStorage;

namespace JXCProject.Bll.Basic
{
    public class EmployeeMT : IEmployeeMT
    {
        IEmployeeRepository employeeRepository;
        IDepartmentRepository deptRepository;
        ICacheStorage cache;
        public EmployeeMT(IEmployeeRepository employeeRepository, IDepartmentRepository deptRepository,ICacheStorage cache)
        {
            this.employeeRepository = employeeRepository;
            this.deptRepository = deptRepository;
            this.cache = cache;
        }

        public void  AddEmployee(Employee employee)
        {
            employee.ID = new Guid();
            employeeRepository.Add(employee);
            employeeRepository.UnitOfWork.Commite();
        }

        public void ModifyEmployee(Employee employee)
        {
            employeeRepository.Modify(employee);
            employeeRepository.UnitOfWork.Commite();
        }

        public void RemoveEmployee(Employee employee)
        {
            employeeRepository.Remove(employee);
            employeeRepository.UnitOfWork.Commite();
        }

        public IEnumerable<Employee> GetPageData(int pageIndex, int pageCount, string departmentId, string employeeName, string orderText, bool ascending, out int recordCount)
        {
            recordCount = employeeRepository.GetByWhere(o => o.DeptId == departmentId && o.Name.Contains(employeeName), true).Count();
            return employeeRepository.GetAll(pageIndex, pageCount, o => o.DeptId == departmentId && o.Name.Contains(employeeName), orderText, ascending, true);
        }


        public void ModifyEmployee(Employee originalEmployee, Employee newEmployee)
        {
            employeeRepository.Modify(originalEmployee, newEmployee);
            employeeRepository.UnitOfWork.Commite();
        }

        public Employee GetEmployeeById(Guid Id)
        {
            Employee employee;
            employee = cache.Retrieve<Employee>(Id.ToString());

            if (employee == null)
            {
                employee= employeeRepository.GetById(Id);
                cache.Add(Id.ToString(), employee);
            }

            return employee;
        }
    }
}
