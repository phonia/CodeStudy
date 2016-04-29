using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JXCProject.Domain.Models;
using JXCProject.Services.DTOs;

namespace JXCProject.Services.Interfaces.Basic
{
   public  interface IProductService 
    {/// <summary>
        /// 添加品种  
        /// </summary>
        /// 
        void AddProduct(ProductDTO product);

        /// <summary>
        /// 修改品种
        /// </summary>
        /// <param name="ProductDTO"></param>
        void ModifyProduct(ProductDTO product);
        /// <summary>
        /// 删除品种
        /// </summary>
        /// <param name="ProductDTO"></param>
        void RemoveProduct(ProductDTO product);
        /// <summary>
        /// 查询品种
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageCount"></param>
        /// <param name="categoryId"></param>
        /// <param name="ProductDTOName"></param>
        /// <returns></returns>
        IEnumerable<ProductDTO> GetPageData(int pageIndex, int pageCount, string categoryId, string productId, string simpleName, string orderText, bool ascending, out int recordCount);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        IEnumerable<ProductDTO> GetProductByCategoryId(string categoryId);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns> 
        int GetProductCountByName(string name);
    }
}
