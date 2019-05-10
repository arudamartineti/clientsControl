using clientsControl.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Persistence
{
    public class clientsControlDbContext : IdentityDbContext<ApplicationUser> //DbContext
    {        
        public clientsControlDbContext(DbContextOptions<clientsControlDbContext> options) : base(options)
        {            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(clientsControlDbContext).Assembly);
        }

        public DbSet<AssetsVersion> AssetsVersions { set; get; }
        public DbSet<Client> Clients { set; get; }
        public DbSet<Configuration> Configuration { set; get; }
        public DbSet<Contact> Contacts { set; get; }
        public DbSet<License> Licenses { set; get; }
        public DbSet<LicenseClientClasification> LicenseClientClasification { set; get; }
        public DbSet<LicenseDetail> LicenseDetail { set; get; }
        public DbSet<LicenseName> LicenseNames { set; get; }
        public DbSet<Module> Module { set; get; }
        public DbSet<PaymentControl> PaymentControls { set; get; }
        public DbSet<StockType> StockTypes { set; get; }
        public DbSet<Contract> Contracts { set; get; }        

    }
}
