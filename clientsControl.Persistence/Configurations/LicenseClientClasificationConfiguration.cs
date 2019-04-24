using clientsControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Persistence.Configurations
{
    public class LicenseClientClasificationConfiguration : IEntityTypeConfiguration<LicenseClientClasification>
    {
        public void Configure(EntityTypeBuilder<LicenseClientClasification> builder)
        {
            builder.HasKey(c => c.Id).ForSqlServerIsClustered(true);

            builder.Property(c => c.Code).HasMaxLength(30);
            builder.Property(c => c.Name).HasMaxLength(120);

            builder.HasOne(c => c.Client).WithMany(c => c.LicenseClasifications).HasForeignKey(c => c.ClientId).HasConstraintName("FK_LicenseClientClasification_Client");

        }
    }
}
