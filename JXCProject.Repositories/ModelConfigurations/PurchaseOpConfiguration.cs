using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;
using JXCProject.Domain.Models;

namespace JXCProject.Repositories.ModelConfigurations
{
    public class PurchaseOpConfiguration : EntityTypeConfiguration<PurchaseOp>
    {
        public PurchaseOpConfiguration()
        {
            ToTable("PurchaseOp");
            HasRequired(o => o.Customer).WithMany(o => o.PurchaseOps).HasForeignKey(k => k.CustomerId);
        }
    }
}
