using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JXCProject.Services.DTOs;
using JXCProject.Domain.Models;
using AutoMapper;

namespace JXCProject.Services.Mapping
{
    public static class ProductMapper
    {
        public static ProductDTO ConvertToProductDto(this Product product)
        {
            return Mapper.Map<Product, ProductDTO>(product);
        }

        public static Product ConvertToProduct(this ProductDTO product)
        {
            return Mapper.Map<ProductDTO, Product>(product);
        }

        public static IEnumerable<ProductDTO> ConvertToProductDtos(this IEnumerable<Product> products)
        {
            return MapperHelper.Map<Product, ProductDTO>(products);
        }
    }
}
