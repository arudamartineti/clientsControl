using clientsControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Persistence.Configurations
{
    public class SupportPlanificationConfiguration : IEntityTypeConfiguration<SupportPlanification>
    {
        public void Configure(EntityTypeBuilder<SupportPlanification> builder)
        {
            builder.HasKey(c => c.Id).ForSqlServerIsClustered(true);
            builder.Property(c => c.Month).HasMaxLength(12);
            builder.Property(c => c.Confirmed).HasDefaultValue(false);
        }
    }
}
