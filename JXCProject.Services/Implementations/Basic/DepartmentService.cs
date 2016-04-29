using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JXCProject.Domain.Models;
using JXCProject.Services.DTOs;
using JXCProject.Services.Interfaces.Basic;
using JXCProject.Services.Mapping;
using JXCProject.Infrastructure.Extesions;

namespace JXCProject.Services.Implementations.Basic 
{
   public  class DepartmentService:IDepartmentService
    {
        IDepartmentRepository departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            this.departmentRepository = departmentRepository;
        }

        public void AddDepartment(DepartmentDTO dto) 
        {
            dto.ParentID = dto.ParentID == DataDictionary.PleaseSelect? null : dto.ParentID;
            dto.ID = BaseDTO.RenderID();
            departmentRepository.Add(dto.ConvertToDepartment());
            departmentRepository.UnitOfWork.Commite();
        }

        public void RemoveDepartment(DepartmentDTO dto)
        {
            departmentRepository.Remove(dto.ConvertToDepartment());
            departmentRepository.UnitOfWork.Commite();
        }

        public void ModifyDepartment(DepartmentDTO dto)
        {
            departmentRepository.Modify(dto.ConvertToDepartment());
            departmentRepository.UnitOfWork.Commite();
        }

        public IEnumerable<DepartmentDTO> GetDepartmentsByParentId(string parentId)
        {
            var query = default(IEnumerable<Department>);

            if (string.IsNullOrEmpty(parentId))
                query = departmentRepository.GetByWhere(o => object.Equals(o.ParentID, null));
            else
                query = departmentRepository.GetByWhere(o => o.ParentID == parentId);

            return query.ConvertToDepartmentDtos();
        }

        public IEnumerable<DepartmentDTO> GetPageData(int pageIndex, int pageCount, string orderText, bool ascending, out int recordCount)
        {
            var query = departmentRepository.GetAll().SelectDepartment(out recordCount);

            return query.Paging(pageIndex, pageCount, orderText, ascending);
        }
    }
}
