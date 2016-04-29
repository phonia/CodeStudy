using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JXCProject.BLL.Basic.IBLL;
using JXCProject.Domain.Models;
using JXCProject.BLL.DTO;

namespace JXCProject.Bll.Basic
{
    public  class DepartmentMT:IDepartmentMT
    {
        IDepartmentRepository departmentRepository;

        public DepartmentMT(IDepartmentRepository departmentRepository)
        {
            this.departmentRepository = departmentRepository;
        }

        public void AddDepartment(Department dept)
        {
            dept.ParentID = dept.ParentID == "--请选择--" ? null : dept.ParentID;
            dept.ID = dept.GetID();
            departmentRepository.Add(dept);
            departmentRepository.UnitOfWork.Commite();
        }

        public void RemoveDepartment(Department dept)
        {
            departmentRepository.Remove(dept);
            departmentRepository.UnitOfWork.Commite();
        }

        public void ModifyDepartment(Department dept)
        {
            departmentRepository.Modify(dept);
            departmentRepository.UnitOfWork.Commite();
        }

        public IEnumerable<Department> GetDepartmentsByParentId(string parentId)
        {
            if (string.IsNullOrEmpty(parentId))
                return departmentRepository.GetByWhere(o => object.Equals(o.ParentID, null));
            else
                return departmentRepository.GetByWhere(o => o.ParentID == parentId);
        }

        public IEnumerable<DepartmentDTO> GetPageData(int pageIndex, int pageCount, string orderText, bool ascending, out int recordCount)
        {
            return departmentRepository.GetAll<DepartmentDTO>(pageIndex, pageCount, SelectDepartment(out recordCount), orderText, ascending);
        }

        private IEnumerable<DepartmentDTO> SelectDepartment(out int recordCount)
        {
            var query = departmentRepository.GetAll().Select(o =>
            {
                var data = departmentRepository.GetByWhere(p => p.ID == o.ParentID).SingleOrDefault();
                return new DepartmentDTO { ID = o.ID, Name = o.Name, ParentName = data == null ? null : data.Name };
            });
            recordCount = query.Count();

            return query;
        }
    }
}
