using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;
using JXCProject.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace JXCProject.Repositories.ModelConfigurations
{
    public class CustomerAddressConfiguration : EntityTypeConfiguration<CustomerAddress>
    {
        public CustomerAddressConfiguration()
        {
            Property(o => o.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(o => o.Address).IsRequired();
            Property(o => o.Reciever).IsRequired();
            Property(o => o.Telephone).IsRequired();
            Property(o => o.ZipCode).IsRequired();
            ToTable("CustomerAddress");
            HasRequired(o => o.Customer).WithMany(o => o.CustomerAddresses).HasForeignKey(k => k.CustomerId);
        }
    }
}
