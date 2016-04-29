using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JXCProject.Domain.Models;
using JXCProject.Services.DTOs;

namespace JXCProject.Services.Interfaces.Basic
{
   public interface IDepartmentService
    {
        void AddDepartment(DepartmentDTO dept);
        void RemoveDepartment(DepartmentDTO dept);
        void ModifyDepartment(DepartmentDTO dept);
        IEnumerable<DepartmentDTO> GetDepartmentsByParentId(string parentId);
        IEnumerable<DepartmentDTO> GetPageData(int pageIndex, int pageCount, string orderText, bool ascending, out int recordCount);
    }
}
