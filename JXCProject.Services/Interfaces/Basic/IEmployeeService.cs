using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JXCProject.Domain.Models;
using JXCProject.Services.DTOs;

namespace JXCProject.Services.Interfaces.Basic
{
   public  interface IEmployeeService
    {
        void AddEmployee(EmployeeDTO employeeDto);
        void ModifyEmployee(EmployeeDTO originalEmployeeDto, EmployeeDTO newEmployeeDto);
        void RemoveEmployee(EmployeeDTO employeeDto);
        EmployeeDTO GetEmployeeById(Guid Id);
        IEnumerable<EmployeeDTO> GetPageData(int pageIndex, int pageCount, string departmentId, string employeeName, string orderText, bool ascending, out int recordCount);
    }
}
