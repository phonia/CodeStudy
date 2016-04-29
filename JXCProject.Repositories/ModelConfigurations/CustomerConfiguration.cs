using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;
using JXCProject.Domain.Models;

namespace JXCProject.Repositories.ModelConfigurations
{
    public class CustomerConfiguration : EntityTypeConfiguration<Customer>
    {
        public CustomerConfiguration()
        {
            Property(o => o.SimpleID).IsRequired();
            Property(o => o.Name).IsRequired();
            Property(o => o.Address).IsRequired().HasMaxLength(500);
            Property(o => o.CstType).IsRequired();
            Property(o => o.Telephone).IsRequired();
            ToTable("Customer");
        }
    }
}
