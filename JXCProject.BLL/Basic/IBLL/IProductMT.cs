using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JXCProject.Domain.Models;

namespace JXCProject.BLL.Basic.IBLL
{
    public interface IProductMT : IDisposable
    {
        /// <summary>
        /// 添加品种
        /// </summary>
        /// 
        void AddProduct(Product product);

        /// <summary>
        /// 修改品种
        /// </summary>
        /// <param name="product"></param>
        void ModifyProduct(Product product);
        /// <summary>
        /// 删除品种
        /// </summary>
        /// <param name="product"></param>
        void RemoveProduct(Product product);
        /// <summary>
        /// 查询品种
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageCount"></param>
        /// <param name="categoryId"></param>
        /// <param name="productName"></param>
        /// <returns></returns>
        IEnumerable<Product> GetPageData(int pageIndex, int pageCount, string categoryId, string productId, string simpleName, string orderText, bool ascending, out int recordCount);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        IEnumerable<Product> GetProductByCategoryId(string categoryId);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        int GetProductCountByName(string name);
    }
}
