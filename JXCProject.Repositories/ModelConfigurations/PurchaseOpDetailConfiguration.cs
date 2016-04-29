using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;
using JXCProject.Domain.Models;

namespace JXCProject.Repositories.ModelConfigurations
{
    public class PurchaseOpDetailConfiguration : EntityTypeConfiguration<PurchaseOpDetail>
    {
        public PurchaseOpDetailConfiguration()
        {
            ToTable("PurchaseOpDetail");
            HasRequired(o => o.PurchaseOp).WithMany(o => o.PurchaseOpDetails).HasForeignKey(k => k.PurchaseOpId);
            HasRequired(o => o.Product).WithMany(o => o.PurchaseOpDetails).HasForeignKey(k => k.ProductId);
        }
    }
}
