using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JXCProject.Domain.Models;
using JXCProject.Services.Interfaces.Basic;
using JXCProject.Services.DTOs;
using JXCProject.Services.Mapping;
using JXCProject.Infrastructure.Extesions;

namespace JXCProject.Services.Implementations.Basic
{
    public class ProductService : IProductService
    {
        IProductRepository productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public void AddProduct(ProductDTO product)
        {
            product.ID = BaseDTO.RenderID();
            productRepository.Add(product.ConvertToProduct());
            productRepository.UnitOfWork.Commite();
        }

        public void ModifyProduct(ProductDTO product)
        {
            productRepository.Modify(product.ConvertToProduct());
            productRepository.UnitOfWork.Commite();
        }

        public void RemoveProduct(ProductDTO product)
        {
            productRepository.Remove(product.ConvertToProduct());
            productRepository.UnitOfWork.Commite();
        }

        public IEnumerable<ProductDTO> GetProductByCategoryId(string categoryId)
        {
            var query = productRepository.GetProductByCategoryId(categoryId);
            return query.ConvertToProductDtos();
        }

        public int GetProductCountByName(string name)
        {
            return productRepository.GetByWhere(o => o.Name == name).Count();
        }

        public IEnumerable<ProductDTO> GetPageData(int pageIndex, int pageCount, string categoryId, string productId, string simpleName, string orderText, bool ascending, out int recordCount)
        {
            var query = productRepository.GetByWhere(o => o.ProductCategoryId == categoryId && o.ID == productId && o.SimpleName.Contains(simpleName), true);
            recordCount = query.Count();
            return query.Paging(pageIndex, pageCount, orderText, ascending).ConvertToProductDtos();
        }
    }
}
