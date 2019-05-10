using clientsControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Persistence.Configurations
{
    public class SupportDayPlanificationConfiguration : IEntityTypeConfiguration<SupportDayPlanification>
    {
        public void Configure(EntityTypeBuilder<SupportDayPlanification> builder)
        {
            builder.HasKey(c => c.Id).ForSqlServerIsClustered(true);
            builder.HasOne(c => c.SupportPlanification).WithMany(c => c.DayPlanifications).HasForeignKey(c => c.SupportPlanificationId);
            builder.HasMany(c => c.Installers);
        }
    }
}
