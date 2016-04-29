using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;
using JXCProject.Domain.Models;

namespace JXCProject.Repositories.ModelConfigurations
{
    public class ProductConfiguration : EntityTypeConfiguration<Product>
    {
        public ProductConfiguration()
        {
            ToTable("Product");
            Property(o => o.Name).IsRequired();
            HasRequired(o => o.ProductCategory).WithMany(o => o.Products).HasForeignKey(k => k.ProductCategoryId);
        }
    }
}
