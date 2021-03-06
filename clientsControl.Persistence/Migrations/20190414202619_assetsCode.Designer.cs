﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using clientsControl.Persistence;

namespace clientsControl.Persistence.Migrations
{
    [DbContext(typeof(clientsControlDbContext))]
    [Migration("20190414202619_assetsCode")]
    partial class assetsCode
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("clientsControl.Domain.Entities.AssetsVersion", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnName("Description")
                        .HasMaxLength(50);

                    b.HasKey("Id")
                        .HasAnnotation("SqlServer:Clustered", true);

                    b.ToTable("AssetsVersions");
                });

            modelBuilder.Entity("clientsControl.Domain.Entities.Client", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AssetsCode");

                    b.Property<string>("Code")
                        .HasMaxLength(12);

                    b.Property<string>("Description")
                        .HasMaxLength(255);

                    b.Property<bool>("Discontinued")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(false);

                    b.HasKey("Id")
                        .HasAnnotation("SqlServer:Clustered", true);

                    b.ToTable("Client");
                });

            modelBuilder.Entity("clientsControl.Domain.Entities.Configuration", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ClientConsecutive");

                    b.Property<string>("GeneratedPaymentControlPath");

                    b.Property<int>("LicenceConsecutive");

                    b.Property<string>("SmtpPassword")
                        .HasMaxLength(255);

                    b.Property<string>("SmtpPort");

                    b.Property<string>("SmtpServer")
                        .HasMaxLength(255);

                    b.Property<string>("StmpUser")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Configuration");
                });

            modelBuilder.Entity("clientsControl.Domain.Entities.Contact", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id");

                    b.Property<Guid>("ClientId");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("Email")
                        .HasMaxLength(250);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("Name")
                        .HasMaxLength(50);

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnName("PhoneNumber")
                        .HasMaxLength(50);

                    b.HasKey("Id")
                        .HasAnnotation("SqlServer:Clustered", true);

                    b.HasIndex("ClientId");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("clientsControl.Domain.Entities.License", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("ClasificationId");

                    b.Property<Guid>("ClientId");

                    b.Property<string>("Code");

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<bool>("Descontinued")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(false);

                    b.Property<string>("Name")
                        .HasMaxLength(100);

                    b.Property<string>("REUP")
                        .HasMaxLength(16);

                    b.Property<Guid>("StockTypeId");

                    b.Property<Guid>("VersionId");

                    b.HasKey("Id");

                    b.HasIndex("ClasificationId");

                    b.HasIndex("ClientId");

                    b.HasIndex("StockTypeId");

                    b.HasIndex("VersionId");

                    b.ToTable("Licenses");
                });

            modelBuilder.Entity("clientsControl.Domain.Entities.LicenseClientClasification", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("ClientId");

                    b.Property<string>("Code")
                        .HasMaxLength(6);

                    b.Property<string>("Name")
                        .HasMaxLength(120);

                    b.HasKey("Id")
                        .HasAnnotation("SqlServer:Clustered", true);

                    b.HasIndex("ClientId");

                    b.ToTable("LicenseClientClasification");
                });

            modelBuilder.Entity("clientsControl.Domain.Entities.LicenseDetail", b =>
                {
                    b.Property<Guid>("LicenceId");

                    b.Property<Guid>("ModuleId");

                    b.Property<int>("Licencias");

                    b.Property<int>("PcAdicionales");

                    b.Property<int>("PcConsultas");

                    b.HasKey("LicenceId", "ModuleId");

                    b.HasIndex("ModuleId");

                    b.ToTable("LicenseDetail");
                });

            modelBuilder.Entity("clientsControl.Domain.Entities.LicenseName", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<Guid>("LicenseId");

                    b.Property<string>("Name")
                        .HasMaxLength(100);

                    b.Property<string>("REUP")
                        .HasMaxLength(16);

                    b.HasKey("Id");

                    b.HasIndex("LicenseId");

                    b.ToTable("LicenseNames");
                });

            modelBuilder.Entity("clientsControl.Domain.Entities.Module", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnName("Description")
                        .HasMaxLength(50);

                    b.Property<int>("WorkStations");

                    b.HasKey("Id")
                        .HasAnnotation("SqlServer:Clustered", true);

                    b.ToTable("Module");
                });

            modelBuilder.Entity("clientsControl.Domain.Entities.PaymentControl", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("ExpirationDate");

                    b.Property<DateTime>("GeneratedDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<Guid>("LicenceId");

                    b.Property<string>("Localization");

                    b.Property<bool>("Public");

                    b.Property<bool>("SendByEmail");

                    b.Property<bool>("SentByEmail");

                    b.Property<DateTime>("SentByEmailDate");

                    b.HasKey("Id");

                    b.HasIndex("LicenceId");

                    b.ToTable("PaymentControls");
                });

            modelBuilder.Entity("clientsControl.Domain.Entities.StockType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnName("Description")
                        .HasMaxLength(50);

                    b.Property<int>("WorkStations")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(0);

                    b.HasKey("Id")
                        .HasAnnotation("SqlServer:Clustered", true);

                    b.ToTable("StockTypes");
                });

            modelBuilder.Entity("clientsControl.Domain.Entities.Contact", b =>
                {
                    b.HasOne("clientsControl.Domain.Entities.Client", "Client")
                        .WithMany("Contacts")
                        .HasForeignKey("ClientId")
                        .HasConstraintName("FK_Contacts_Client")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("clientsControl.Domain.Entities.License", b =>
                {
                    b.HasOne("clientsControl.Domain.Entities.LicenseClientClasification", "Clasification")
                        .WithMany("Licenses")
                        .HasForeignKey("ClasificationId")
                        .HasConstraintName("FK_License_ClientClasification")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("clientsControl.Domain.Entities.Client", "Client")
                        .WithMany("Licenses")
                        .HasForeignKey("ClientId")
                        .HasConstraintName("FK_LicenseClient")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("clientsControl.Domain.Entities.StockType", "StockType")
                        .WithMany("Licenses")
                        .HasForeignKey("StockTypeId")
                        .HasConstraintName("FK_LicenseStockType")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("clientsControl.Domain.Entities.AssetsVersion", "Version")
                        .WithMany("Licenses")
                        .HasForeignKey("VersionId")
                        .HasConstraintName("FK_LicenseVersion")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("clientsControl.Domain.Entities.LicenseClientClasification", b =>
                {
                    b.HasOne("clientsControl.Domain.Entities.Client", "Client")
                        .WithMany("LicenseClasifications")
                        .HasForeignKey("ClientId")
                        .HasConstraintName("FK_LicenseClientClasification_Client")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("clientsControl.Domain.Entities.LicenseDetail", b =>
                {
                    b.HasOne("clientsControl.Domain.Entities.License", "License")
                        .WithMany("LicenseDetails")
                        .HasForeignKey("LicenceId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("clientsControl.Domain.Entities.Module", "Module")
                        .WithMany("LicenseDetails")
                        .HasForeignKey("ModuleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("clientsControl.Domain.Entities.LicenseName", b =>
                {
                    b.HasOne("clientsControl.Domain.Entities.License", "License")
                        .WithMany("LicenseNames")
                        .HasForeignKey("LicenseId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("clientsControl.Domain.Entities.PaymentControl", b =>
                {
                    b.HasOne("clientsControl.Domain.Entities.License", "License")
                        .WithMany("PaymentsControl")
                        .HasForeignKey("LicenceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
