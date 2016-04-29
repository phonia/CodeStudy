using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JXCProject.Domain.Models;
using JXCProject.BLL.DTO;

namespace JXCProject.BLL.Basic.IBLL
{
    public interface IProductCategoryMT:IDisposable
    {
        /// <summary>
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
        /// <param name="productCategory"></param>
        void RemoveProductCategory(ProductCategory productCategory);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerable<ProductCategory> GetProductCategories();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageCount"></param>
        /// <param name="orderText"></param>
        /// <param name="ascending"></param>
        /// <returns></returns>
        IEnumerable<ProductCategoryDTO> GetPageData(string categoryName, int pageIndex, int pageCount, string orderText, bool ascending,out int recordCount);

        ProductCategory GetProductCategoryById(string id);

        IEnumerable<ProductCategory> GetProductCategoriesByParentId(string parentId);
    }
}
