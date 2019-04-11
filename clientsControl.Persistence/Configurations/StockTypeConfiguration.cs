using clientsControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Persistence.Configurations
{
    public class StockTypeConfiguration : IEntityTypeConfiguration<StockType>
    {
        public void Configure(EntityTypeBuilder<StockType> builder)
        {
            builder.HasKey(c => c.Id).ForSqlServerIsClustered(true);

            builder.Property(e => e.Id).HasColumnName("Id");
            builder.Property(e => e.Description).HasColumnName("Description").IsRequired().HasMaxLength(50);
            builder.Property(e => e.WorkStations).HasDefaultValue(0);
        }
    }
}
