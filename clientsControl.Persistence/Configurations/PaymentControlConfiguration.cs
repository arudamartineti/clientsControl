using clientsControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Persistence.Configurations
{
    public class PaymentControlConfiguration : IEntityTypeConfiguration<PaymentControl>
    {
        public void Configure(EntityTypeBuilder<PaymentControl> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.GeneratedDate).HasDefaultValueSql("GETDATE()");
            builder.HasOne(c => c.License).WithMany(c => c.PaymentsControl).HasForeignKey(c => c.LicenceId);

        }
    }
}
