using clientsControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Persistence.Configurations
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Client");

            builder.HasKey(c => c.Id).ForSqlServerIsClustered(true);

            builder.Property(e => e.Description).HasMaxLength(255);
            builder.Property(e => e.Code).HasMaxLength(12);
            builder.Property(e => e.Discontinued).HasDefaultValue(false);

            builder.HasMany(c => c.LicenseClasifications).WithOne(c => c.Client).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(c => c.Contacts).WithOne(c => c.Client).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
