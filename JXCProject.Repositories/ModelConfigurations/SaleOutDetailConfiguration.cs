using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;
using JXCProject.Domain.Models;

namespace JXCProject.Repositories.ModelConfigurations
{
    public class SaleOutDetailConfiguration : EntityTypeConfiguration<SaleOutDetail>
    {
        public SaleOutDetailConfiguration()
        {
            ToTable("SaleOutDetail");
            HasKey(k => new { k.SaleOutId, k.WarePositionId,k.ProductId });
            HasRequired(o => o.SaleOut).WithMany(o => o.SaleOutDetails).HasForeignKey(k => k.SaleOutId);
            HasRequired(o => o.PositionStock).WithMany(o => o.SaleOutDetails).HasForeignKey(k => new { k.WarePositionId, k.ProductId }).WillCascadeOnDelete(false);
        }
    }
}
