using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;
using JXCProject.Domain.Models;

namespace JXCProject.Repositories.ModelConfigurations
{
    public class SaleOrderConfiguration : EntityTypeConfiguration<SaleOrder>
    {
        public SaleOrderConfiguration()
        {
            ToTable("SaleOrder");
            Property(o => o.SaleQty).IsRequired();
            Property(o => o.SaleType).IsRequired();
            Property(o => o.SaleAmount).IsRequired();
            HasRequired(o => o.Customer).WithMany(o => o.SaleOrdres).HasForeignKey(k => k.CustomerId);
        }
    }
}
