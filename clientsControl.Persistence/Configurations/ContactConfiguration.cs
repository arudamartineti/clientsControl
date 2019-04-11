using clientsControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Persistence.Configurations
{
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.HasKey(c => c.Id).ForSqlServerIsClustered(true);

            builder.Property(e => e.Id).HasColumnName("Id");
            builder.Property(e => e.Name).HasColumnName("Name").IsRequired().HasMaxLength(50);
            builder.Property(e => e.Email).HasColumnName("Email").IsRequired().HasMaxLength(250);
            builder.Property(e => e.PhoneNumber).HasColumnName("PhoneNumber").IsRequired().HasMaxLength(50);

            builder.HasOne(c => c.Client).WithMany(c => c.Contacts).HasForeignKey(c => c.ClientId).HasConstraintName("FK_Contacts_Client");


        }
    }
}
