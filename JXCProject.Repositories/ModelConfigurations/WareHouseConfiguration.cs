using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;
using JXCProject.Domain.Models;

namespace JXCProject.Repositories.ModelConfigurations
{
    public class WareHouseConfiguration : EntityTypeConfiguration<WareHouse>
    {
        public WareHouseConfiguration()
        {
            ToTable("WareHouse");
            Property(o => o.Name).IsRequired();
            Property(o => o.Address).IsRequired();
            Property(o => o.Linkman).IsRequired();
            Property(o => o.Telephone).IsRequired();
            Property(o => o.ZipCode).IsRequired();
        }
    }
}
