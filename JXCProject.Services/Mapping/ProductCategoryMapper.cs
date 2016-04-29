using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JXCProject.Services.DTOs;
using JXCProject.Domain.Models;
using AutoMapper;

namespace JXCProject.Services.Mapping
{
    public static class ProductCategoryMapper
    {
        public static IEnumerable<ProductCategoryDTO> ConvertToProductCategoryDtos(this IEnumerable<ProductCategory> productCategories)
        {
           return  MapperHelper.Map<ProductCategory, ProductCategoryDTO>(productCategories);
        }

        public static IEnumerable<ProductCategoryDTO> SelectProductCategory(this IProductCategoryRepository productCategoryRepository, string categoryName, out int recordCount)
        {
            var query = productCategoryRepository.GetByWhere(o => o.CategoryName.Contains(categoryName), true).Select(o =>
            {
                var data = productCategoryRepository.GetByWhere(p => p.ID == o.ParentID).SingleOrDefault();
                return new ProductCategoryDTO { ID = o.ID, CategoryName = o.CategoryName, ParentName = data == null ? null : data.CategoryName };
            });
            recordCount = query.Count();

            return query;
        }
    }
}
