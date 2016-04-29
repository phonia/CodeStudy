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
    public class ProductCategoryService : IProductCategoryService
    {
        IProductCategoryRepository productCategoryRepository;

        public ProductCategoryService(IProductCategoryRepository productCategoryRepository)
        {
            this.productCategoryRepository = productCategoryRepository;
        }

        public void ModifyProductCategory(string parentID, string id)
        {
            ProductCategory productCategory = this.GetProductCategoryById(id);
            productCategory.ParentID = parentID;
            productCategoryRepository.Modify(productCategory);
            productCategoryRepository.UnitOfWork.Commite();
        }

        public void AddProductCategory(string parentID, string categoryName)
        {
            ProductCategory productCategory = new ProductCategory();
            productCategory.ID = productCategory.GetID();
            if (!string.IsNullOrEmpty(parentID) && parentID != DataDictionary.PleaseSelect)
                productCategory.ParentID = parentID;
            productCategory.CategoryName = categoryName;
            productCategoryRepository.Add(productCategory);
            productCategoryRepository.UnitOfWork.Commite();
        }

        public void RemoveProductCategory(string id)
        {
            productCategoryRepository.Remove(this.GetProductCategoryById(id));
            productCategoryRepository.UnitOfWork.Commite();
        }

        public IEnumerable<ProductCategoryDTO> GetProductCategories()
        {
            return productCategoryRepository.GetAll().ConvertToProductCategoryDtos();
        }

        public IEnumerable<ProductCategoryDTO> GetProductCategoriesByParentId(string parentId)
        {
            var query = default(IEnumerable<ProductCategory>);
            if (string.IsNullOrEmpty(parentId))
                query= productCategoryRepository.GetByWhere(o => object.Equals(o.ParentID, null));
            else
                query= productCategoryRepository.GetByWhere(o => o.ParentID == parentId);

            return query.ConvertToProductCategoryDtos();
        }

        public IEnumerable<ProductCategoryDTO> GetPageData(string categoryName, int pageIndex, int pageCount, string orderText, bool ascending, out int recordCount)
        {
            var query = productCategoryRepository.SelectProductCategory(categoryName, out recordCount);
            return query.Paging(pageIndex, pageCount, orderText, ascending);
        }

        public ProductCategory GetProductCategoryById(string id)
        {
            return productCategoryRepository.GetById<string>(id);
        }

        public void Dispose()
        {
            productCategoryRepository.Dispose();
        }
    }
}
