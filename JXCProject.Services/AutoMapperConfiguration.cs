using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using JXCProject.Domain.Models;
using JXCProject.Services.DTOs;

namespace JXCProject.Services
{
    public class AutoMapperConfiguration
    {
        public static void ConfigureAutoMapper()
        {
            //基础资料管理配置
            Mapper.CreateMap<Product, ProductDTO>();
            Mapper.CreateMap<ProductDTO, Product>();
            Mapper.CreateMap<ProductCategory, ProductCategoryDTO>().
                ForMember(d => d.ParentName, s => s.Ignore());
            Mapper.CreateMap<ProductCategoryDTO, ProductCategory>();
            Mapper.CreateMap<Customer, CustomerDTO>();
            Mapper.CreateMap<CustomerDTO, Customer>();
            Mapper.CreateMap<CustomerAddress, CustomerAddressDTO>();
            Mapper.CreateMap<CustomerAddressDTO, CustomerAddress>();
            Mapper.CreateMap<Employee, EmployeeDTO>();
            Mapper.CreateMap<EmployeeDTO, Employee>();
            Mapper.CreateMap<Department, DepartmentDTO>().
                ForMember(d => d.ParentName, s => s.Ignore());
            Mapper.CreateMap<DepartmentDTO, Department>();

            //采购配置
            Mapper.CreateMap<PurchaseOp, PurchaseOpDTO>();
            Mapper.CreateMap<PurchaseOpDTO, PurchaseOp>();
            Mapper.CreateMap<PurchaseOpDetail, PurchaseOpDetailDTO>();
            Mapper.CreateMap<PurchaseOpDetailDTO, PurchaseOpDetail>();
        }
    }
}
