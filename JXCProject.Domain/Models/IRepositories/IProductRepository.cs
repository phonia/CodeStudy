using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JXCProject.Infrastructure.Domain;

namespace JXCProject.Domain.Models
{
    public interface IProductRepository : IRepository<Product>
    {
        IEnumerable<Product> GetProductByCategoryId(string categoryId);
        IEnumerable<Product> GetProductByCategoryIdAndName(string categoryId, string name);
        Product GetProductById(string productId);
    }
}
