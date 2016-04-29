using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;
using JXCProject.Domain.Models;

namespace JXCProject.Repositories.ModelConfigurations
{
    public class SaleOrderDetailConfiguration : EntityTypeConfiguration<SaleOrderDetail>
    {
        public SaleOrderDetailConfiguration()
        {
            ToTable("SaleOrderDetail");
            HasKey(k => new { k.ProductId, k.SaleOrderId });
            HasRequired(o => o.Product).WithMany(o => o.SaleOrderDetails).HasForeignKey(k => k.ProductId);
            HasRequired(o => o.SaleOrder).WithMany(o => o.SaleOrderDetails).HasForeignKey(k => k.SaleOrderId);
            HasRequired(o => o.Employee).WithMany(o => o.SaleOrderDetails).HasForeignKey(k => k.EmpId);
        }
    }
}
