using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JXCProject.Repositories;
using JXCProject.Domain.Models;

namespace JXCProject.Repositories
{
    public class ProductCategoryRepository : Repository<ProductCategory>, IProductCategoryRepository
    {
        public ProductCategoryRepository(JXCContext unitOfWork)
            : base(unitOfWork)
        { }
    }
}
