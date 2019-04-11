using clientsControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Persistence.Configurations
{
    public class ConfigurationConfiguration : IEntityTypeConfiguration<Configuration>
    {
        public void Configure(EntityTypeBuilder<Configuration> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.SmtpPassword).HasMaxLength(255);
            builder.Property(c => c.SmtpServer).HasMaxLength(255);
            builder.Property(c => c.StmpUser).HasMaxLength(255);

        }
    }
}
