using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JXCProject.Domain.Models;
using JXCProject.BLL.DTO;

namespace JXCProject.BLL.Basic.IBLL
{
   public  interface IDepartmentMT
    {
       void AddDepartment(Department dept);
       void RemoveDepartment(Department dept);
       void ModifyDepartment(Department dept);
       IEnumerable<Department> GetDepartmentsByParentId(string parentId);
       IEnumerable<DepartmentDTO> GetPageData(int pageIndex, int pageCount, string orderText, bool ascending, out int recordCount);
    }
}
