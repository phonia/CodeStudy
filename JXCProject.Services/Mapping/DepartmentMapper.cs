using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JXCProject.Services.DTOs;
using JXCProject.Domain.Models;
using AutoMapper;

namespace JXCProject.Services.Mapping
{
    public static  class DepartmentMapper
    {
        public static Department ConvertToDepartment(this DepartmentDTO dto)
        {
            return Mapper.Map<DepartmentDTO, Department>(dto);
        }

        public static IEnumerable<DepartmentDTO> ConvertToDepartmentDtos(this IEnumerable<Department> depts)
        {
            return MapperHelper.Map<Department, DepartmentDTO>(depts);
        }

        public static IEnumerable<DepartmentDTO> SelectDepartment(this IEnumerable<Department> depts,out int recordCount)
        {
            var query = depts.Select(o =>
            {
                var data = depts.Where(p => p.ID == o.ParentID).SingleOrDefault();
                return new DepartmentDTO { ID = o.ID, Name = o.Name, ParentName = data == null ? null : data.Name };
            });
            recordCount = query.Count();

            return query;
        }
    }
}
