using clientsControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Persistence.Configurations
{
    public class LicenseDetailConfiguration : IEntityTypeConfiguration<LicenseDetail>
    {
        public void Configure(EntityTypeBuilder<LicenseDetail> builder)
        {
            builder.HasKey(c => new { c.LicenceId, c.ModuleId});

            builder.HasOne(c => c.Module).WithMany(c => c.LicenseDetails).HasForeignKey(c => c.ModuleId);
            builder.HasOne(c => c.License).WithMany(c => c.LicenseDetails).HasForeignKey(c => c.LicenceId);
        }
    }
}
