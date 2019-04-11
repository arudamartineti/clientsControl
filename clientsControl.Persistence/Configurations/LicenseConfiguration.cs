using clientsControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Persistence.Configurations
{
    public class LicenseConfiguration : IEntityTypeConfiguration<License>
    {
        public void Configure(EntityTypeBuilder<License> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.REUP).HasMaxLength(16);
            builder.Property(c => c.Name).HasMaxLength(100);
            builder.Property(c => c.CreationDate).HasDefaultValueSql("GETDATE()");
            builder.Property(c => c.Descontinued).HasDefaultValue(false);            

            builder.HasOne(c => c.Client).WithMany(c => c.Licenses).HasForeignKey(c => c.ClientId).HasConstraintName("FK_LicenseClient");
            builder.HasOne(c => c.Clasification).WithMany(c => c.Licenses).HasForeignKey(c => c.ClasificationId).HasConstraintName("FK_License_ClientClasification");
            builder.HasOne(c => c.StockType).WithMany(c => c.Licenses).HasForeignKey(c => c.StockTypeId).HasConstraintName("FK_LicenseStockType");
            builder.HasOne(c => c.Version).WithMany(c => c.Licenses).HasForeignKey(c => c.VersionId).HasConstraintName("FK_LicenseVersion");
            
        }
    }
}
