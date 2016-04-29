using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JXCProject.Domain.Models;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace JXCProject.Repositories.ModelConfigurations
{
    public class EmployeeConfiguration : EntityTypeConfiguration<Employee>
    {
        public EmployeeConfiguration()
        {
            Property(o => o.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(o => o.Name).IsRequired();
            Property(o => o.Gender).IsRequired();
            Property(o => o.IDCard).IsRequired();
            Property(o => o.Race).IsRequired();
            ToTable("Employee");
            HasOptional(o => o.Department).WithMany(o => o.Employees).HasForeignKey(k => k.DeptId);
        }
    }
}
