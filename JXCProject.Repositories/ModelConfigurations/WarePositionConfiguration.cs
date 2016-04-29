using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;
using JXCProject.Domain.Models;

namespace JXCProject.Repositories.ModelConfigurations
{
   public  class WarePositionConfiguration:EntityTypeConfiguration<WarePosition>
    {
       public WarePositionConfiguration()
       {
           ToTable("WarePosition");
           HasRequired(o => o.WareHouse).WithMany(o => o.WarePostions).HasForeignKey(k => k.WareHouseId);
       }
    }
}
