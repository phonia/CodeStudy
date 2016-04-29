using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JXCProject.Domain.Models;
using JXCProject.BLL.Basic.IBLL;
using JXCProject.BLL.DTO;

namespace JXCProject.Bll.Basic
{
    public class  ProductCategoryMT:IProductCategoryMT
    {
        IProductCategoryRepository productCategoryRepository;

        public ProductCategoryMT(IProductCategoryRepository productCategoryRepository)
        {
            this.productCategoryRepository = productCategoryRepository;
        }

        public void ModifyProductCategory(string parentID,string id)
        {
            ProductCategory productCategory = productCategoryRepository.GetById<string>(id);
            productCategory.ParentID = parentID;
            productCategoryRepository.Modify(productCategory);
            productCategoryRepository.UnitOfWork.Commite();
        }

        public void AddProductCategory(string parentID, string categoryName)
        {
            ProductCategory productCategory = new ProductCategory();
            productCategory.ID = productCategory.GetID();
            if (!string.IsNullOrEmpty(parentID))
                productCategory.ParentID = parentID;
            productCategory.CategoryName = categoryName;
            productCategoryRepository.Add(productCategory);
            productCategoryRepository.UnitOfWork.Commite();
        }

        public void RemoveProductCategory(ProductCategory productCategory)
        {
            productCategoryRepository.Remove(productCategory);
            productCategoryRepository.UnitOfWork.Commite();
        }

        public IEnumerable<ProductCategory> GetProductCategories()
        {
            return productCategoryRepository.GetAll();
        }

        public IEnumerable<ProductCategory> GetProductCategoriesByParentId(string parentId)
        {
            if (string.IsNullOrEmpty(parentId))
                return productCategoryRepository.GetByWhere(o => object.Equals(o.ParentID, null));
            else
                return productCategoryRepository.GetByWhere(o => o.ParentID == parentId);
        }

        public IEnumerable<ProductCategoryDTO> GetPageData(string categoryName,int pageIndex, int pageCount, string orderText, bool ascending,out int recordCount)
        {
            categoryName = string.IsNullOrEmpty(categoryName) ? null : categoryName;
            return productCategoryRepository.GetAll<ProductCategoryDTO>(pageIndex, pageCount, SelectProductCategory(categoryName,out recordCount), orderText, ascending);
        }

        public ProductCategory GetProductCategoryById(string id)
        {
            return productCategoryRepository.GetById<string>(id);
        }

        public void Dispose()
        {
            productCategoryRepository.Dispose();
        }

        private IEnumerable<ProductCategoryDTO> SelectProductCategory(string categoryName, out int recordCount)
        {
            var query = productCategoryRepository.GetByWhere(o => o.CategoryName.Contains(categoryName), true).Select(o =>
            {
                var data = productCategoryRepository.GetByWhere(p => p.ID == o.ParentID).SingleOrDefault();
                return new ProductCategoryDTO { ID = o.ID, Name = o.CategoryName, ParentName = data == null ? null : data.CategoryName };
            });
            recordCount = query.Count();

            return query;
        }
    }
}
