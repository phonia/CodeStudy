using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JXCProject.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace JXCProject.Repositories.ModelConfigurations
{
    public class PositionStockConfiguration : EntityTypeConfiguration<PositionStock>
    {
        public PositionStockConfiguration()
        {
            ToTable("PositionStock");
            HasKey(k => new { k.WarePositionId, k.ProductId });
            HasRequired(o => o.WarePostion).WithMany(o => o.PositionStocks).HasForeignKey(k => k.WarePositionId);
            HasRequired(o => o.Product).WithMany(o => o.PositionStocks).HasForeignKey(k => k.ProductId);
        }
    }
}
