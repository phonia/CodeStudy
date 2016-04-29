using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JXCProject.Domain.Models;

namespace JXCProject.BLL.Basic.IBLL
{
    public interface IEmployeeMT
    {
        void AddEmployee(Employee employee);
        void ModifyEmployee(Employee employee);
        void ModifyEmployee(Employee originalEmployee, Employee newEmployee);
        void RemoveEmployee(Employee employee);
        Employee GetEmployeeById(Guid Id);
        IEnumerable<Employee> GetPageData(int pageIndex, int pageCount, string departmentId, string employeeName, string orderText, bool ascending, out int recordCount);
    }
}
