using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using JXCProject.Domain.Models;

namespace JXCProject.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(JXCContext unitOfWork)
            : base(unitOfWork)
        { }

        public IEnumerable<Product> GetProductByCategoryId(string categoryId)
        {
            return base.GetByWhere(o => o.ProductCategoryId == categoryId);
        }

        public IEnumerable<Product> GetProductByCategoryIdAndName(string categoryId, string name)
        {
            return this.GetProductByCategoryId(categoryId).Where(o => o.Name.Contains(name) || o.SimpleName.Contains(name));
        }

        public Product GetProductById(string productId)
        {
            return this.GetById(productId);
        }
    }
}

