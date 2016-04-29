using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JXCProject.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace JXCProject.Repositories.ModelConfigurations
{
    public class ProductCategoryConfiguration : EntityTypeConfiguration<ProductCategory>
    {
        public ProductCategoryConfiguration()
        {
            ToTable("ProductCategory");
            Property(o => o.CategoryName).IsRequired();
        }
    }
}
