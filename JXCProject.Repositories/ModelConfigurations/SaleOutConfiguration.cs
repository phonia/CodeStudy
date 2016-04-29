using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;
using JXCProject.Domain.Models;

namespace JXCProject.Repositories.ModelConfigurations
{
   public  class SaleOutConfiguration:EntityTypeConfiguration<SaleOut>
    {
       public SaleOutConfiguration()
       {
           ToTable("SaleOut");
           Property(o => o.OutDate).IsRequired();
           Property(o => o.Type).IsRequired();
           Property(o => o.RevAddress).IsRequired();
           Property(o => o.RevPhone).IsRequired();
           Property(o => o.RevZip).IsRequired();
           Property(o => o.Rceiver).IsRequired();
           Property(o => o.Qty).IsRequired();
           HasRequired(o => o.SaleOrderDetail).WithMany(o => o.SaleOuts).Map(m => m.MapKey("ProductId", "SaleOrderId"));
       }
    }
}


