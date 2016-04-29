using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JXCProject.Domain.Models;
using JXCProject.BLL.Basic.IBLL;

namespace JXCProject.Bll.Basic
{
    public class ProductMT : IProductMT
    {
        IProductRepository productRepository;

        public ProductMT(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public void AddProduct(Product product)
        {
            product.ID = product.GetID();
            productRepository.Add(product);
            productRepository.UnitOfWork.Commite();
        }

        public void ModifyProduct(Product product)
        {
            productRepository.Modify(product);
            productRepository.UnitOfWork.Commite();
        }

        public void RemoveProduct(Product product)
        {
            productRepository.Remove(product);
            productRepository.UnitOfWork.Commite();
        }

        public IEnumerable<Product> GetProductByCategoryId(string categoryId)
        {
            return productRepository.GetByWhere(o => o.ProductCategoryId == categoryId);
        }

        public int GetProductCountByName(string name)
        {
           return  productRepository.GetByWhere(o => o.Name == name).Count();
        }

        public IEnumerable<Product> GetPageData(int pageIndex, int pageCount, string categoryId, string productId, string simpleName, string orderText, bool ascending, out int recordCount)
        {
            var query = productRepository.GetByWhere(o => o.ProductCategoryId == categoryId && o.ID == productId && o.SimpleName.Contains(simpleName), true);
            recordCount = query.Count();
            return productRepository.GetAll(pageIndex, pageCount, query, orderText, ascending);
        }

        public void Dispose()
        {
            productRepository.Dispose();
        }
    }
}
