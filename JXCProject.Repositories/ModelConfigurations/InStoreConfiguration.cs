using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JXCProject.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace JXCProject.Repositories.ModelConfigurations
{
    public class InStoreConfiguration : EntityTypeConfiguration<InStore>
    {
        public InStoreConfiguration()
        {
            ToTable("InStore");
            HasRequired(o => o.Customer).WithMany(o => o.InStores).HasForeignKey(k => k.CustomerId);
            HasRequired(o => o.Product).WithMany(o => o.InStores).HasForeignKey(k => k.ProductId);
        }
    }
}
