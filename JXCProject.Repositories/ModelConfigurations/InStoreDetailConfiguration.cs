using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JXCProject.Domain.Models;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace JXCProject.Repositories.ModelConfigurations
{
    public class InStoreDetailConfiguration : EntityTypeConfiguration<InStoreDetail>
    {
        public InStoreDetailConfiguration()
        {
            ToTable("InStoreDetail"); 
            Property(o => o.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasMany(o => o.WarePositions).WithMany(o => o.InStoreDetails)
                .Map(m =>
                {
                    m.ToTable("InStorePosistion");
                    m.MapLeftKey("WarePositionId");
                    m.MapRightKey("InStoreDetailId");
                });
            HasRequired(o => o.InStore).WithMany(o => o.InStoreDetails).HasForeignKey(k => k.InStoreId);
        }
    }
}
