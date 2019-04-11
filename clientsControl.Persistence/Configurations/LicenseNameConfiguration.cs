using clientsControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Persistence.Configurations
{
    public class LicenseNameConfiguration : IEntityTypeConfiguration<LicenseName>
    {
        public void Configure(EntityTypeBuilder<LicenseName> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name).HasMaxLength(100);
            builder.Property(c => c.REUP).HasMaxLength(16);

            builder.HasOne(c => c.License).WithMany(c => c.LicenseNames).HasForeignKey(c => c.LicenseId);            

        }
    }
}
