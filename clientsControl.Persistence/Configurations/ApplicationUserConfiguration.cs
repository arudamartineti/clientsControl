using clientsControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Persistence.Configurations
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Property(c => c.FullName).HasMaxLength(255);
            builder.Property(c => c.ComercialAuthorized).HasDefaultValue(false);
            builder.Property(c => c.ClientUser).HasDefaultValue(false);
            builder.Property(c => c.ClientReup).IsRequired(false);

            builder.HasMany(c => c.SupportDays);
        }
    }
}
