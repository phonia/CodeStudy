using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JXCProject.Domain.Models;
using JXCProject.Services.DTOs;

namespace JXCProject.Services.Interfaces.Basic
{
   public  interface IProductCategoryService
    {/// <summary>
        /// 添加品种分类
        /// </summary>
        /// <param name="parentID"></param>
        /// <param name="categoryName"></param>
        void AddProductCategory(string parentID, string categoryName);
        /// <summary>
        /// 修改品种分类
        /// </summary>
        /// <param name="parentID"></param>
        /// <param name="id"></param>
        void ModifyProductCategory(string parentID, string id);
        /// 删除品种分类
        /// </summary>
        /// <param name="id"></param>
        void RemoveProductCategory(string  id);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerable<ProductCategoryDTO> GetProductCategories();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageCount"></param>
        /// <param name="orderText"></param>
        /// <param name="ascending"></param>
        /// <returns></returns>
        IEnumerable<ProductCategoryDTO> GetPageData(string categoryName, int pageIndex, int pageCount, string orderText, bool ascending, out int recordCount);

        ProductCategory GetProductCategoryById(string id);

        IEnumerable<ProductCategoryDTO> GetProductCategoriesByParentId(string parentId);
    }
}
