using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JXCProject.Services.DTOs;
using JXCProject.Domain.Models;
using AutoMapper;

namespace JXCProject.Services.Mapping
{
  public static class EmployeeMapper
    {
      public static EmployeeDTO ConvertToEmployeeDto(this Employee employee)
      {
          return Mapper.Map<Employee, EmployeeDTO>(employee);  
      }

      public static Employee ConvertToEmployee(this EmployeeDTO employee)
      {
          return Mapper.Map<EmployeeDTO, Employee>(employee);
      } 

      public static IEnumerable<EmployeeDTO> ConvertToEmployeeDtos(this IEnumerable<Employee> employees)
      {
          return MapperHelper.Map<Employee, EmployeeDTO>(employees);
      }
    }
}
