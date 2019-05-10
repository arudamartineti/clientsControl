using clientsControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Persistence.Configurations
{
    public class ContractConfiguration : IEntityTypeConfiguration<Contract>
    {
        public void Configure(EntityTypeBuilder<Contract> builder)
        {
            builder.ToTable("Contract");

            builder.HasKey(c => c.Id).ForSqlServerIsClustered(true);

            builder.HasOne(c => c.Client).WithMany(c => c.Contracts).HasForeignKey(c => c.ClientId);

            builder.Property(c => c.Numero).IsRequired(true).HasMaxLength(255);
            builder.Property(c => c.Suplemento).HasDefaultValue(false);
            builder.Property(c => c.NumeroSuplement).HasDefaultValue(0);
            builder.Property(c => c.FechaEntrega).IsRequired(false);
            builder.Property(c => c.FechaFirma).IsRequired(false);
            builder.Property(c => c.FechaEntrega).IsRequired(false);            

            builder.HasOne(c => c.Instalador).WithMany(c => c.Contracts).HasForeignKey(c => c.IdInstalador);

            builder.Property(c => c.Ubicacion).IsRequired(false);
            builder.Property(c => c.Objeto).HasMaxLength(1024).IsRequired();

            builder.Property(c => c.ImporteLicenciasCUC).HasDefaultValue(0);
            builder.Property(c => c.ImporteLicenciasMN).HasDefaultValue(0);

            builder.Property(c => c.ImportePostVentaCUC).HasDefaultValue(0);
            builder.Property(c => c.ImportePostVentaMN).HasDefaultValue(0);

            builder.Property(c => c.MesInicioPostVenta).IsRequired(false).HasMaxLength(12);
            builder.Property(c => c.MesFinalPostVenta).IsRequired(false).HasMaxLength(12);
            builder.Property(c => c.AnoFinalPostVenta).IsRequired(false);

            builder.Property(c => c.Master).IsRequired(false).HasMaxLength(2048);

            builder.Property(c => c.Discontinued).HasDefaultValue(false);

        }
    }
}
