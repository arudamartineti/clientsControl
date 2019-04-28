using clientsControl.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace clientsControl.Persistence
{
    public class clientsControlInitializer
    {
        public static void Initialize(clientsControlDbContext context)
        {
            var initializer = new clientsControlInitializer();
            initializer.SeedEverything(context);
        }

        public void SeedConfiguration(clientsControlDbContext context)
        {
            if (!context.Configuration.Any())
            {
                var configuration = new Configuration() { Id = Guid.Empty, ClientConsecutive = 0, GeneratedPaymentControlPath = "D:\\PC", LicenceConsecutive = 0, SmtpPassword = "", SmtpPort = "25", SmtpServer = "smtp.com", StmpUser = "user" };
                context.Configuration.Add(configuration);
                context.SaveChanges();
            }
        }

        public void SeedAssetsVersoin(clientsControlDbContext context)
        {
            if (context.AssetsVersions.Any())
            {
                return; // Db has been seeded
            }

            var assetsVersions = new[]
            {
                new AssetsVersion() { Id = Guid.Parse("0B9630E5-2CE2-4A16-AB0D-0F1212CC14E3"), Description = "Assets Ultimate" },
                new AssetsVersion() { Id = Guid.Parse("D20D4D2C-2E7A-4CF6-AD4F-3580B68BBDC4"), Description = "Assets Premium" },
                new AssetsVersion() { Id = Guid.Parse("0A8614B7-C9BD-4A01-93E3-4A234C74D01B"), Description = "Assets Ultimate sin Web" }
            };
            context.AssetsVersions.AddRange(assetsVersions);
            context.SaveChanges();

        }

        public void SeedModules(clientsControlDbContext context)
        {
            if (context.AssetsVersions.Any())
            {
                return;
            }

            var modules = new[]
            {
                new Module() { Id = Guid.Parse("B5670079-D5D1-4CEC-BFD1-3C9380E1D637"), Description = "Assets Ultimate Administracion Web", WorkStations = 0 },
                new Module() { Id = Guid.Parse("FAC5D75B-2021-48E8-B659-4A73B5A9EB19"), Description = "Modulos Complementarios", WorkStations = 1 },
                new Module() { Id = Guid.Parse("A509E5D9-EDF9-40D7-B78F-4D4B6ACE6905"), Description = "Relaciones con Clientes", WorkStations = 2 },
                new Module() { Id = Guid.Parse("2529F593-EAB7-4EAC-AA06-62D012F83C86"), Description = "Finanzas", WorkStations = 4 },
                new Module() { Id = Guid.Parse("93AA48B5-2BDF-48AF-9745-697FBDB87708"), Description = "Personal y Nominas", WorkStations = 3 },
                new Module() { Id = Guid.Parse("0EE63CCA-8F24-40DA-9AF0-6CF68262A768"), Description = "Auditorias", WorkStations = 3 },
                new Module() { Id = Guid.Parse("A8843CDF-4C7C-4BFA-9BD5-786584CC4870"), Description = "Assets Ultimate Proyectos Web", WorkStations = 0 },
                new Module() { Id = Guid.Parse("55AF5C26-3A39-40E0-B9DE-89D9B102CB55"), Description = "Comunicaciones", WorkStations = 1 },
                new Module() { Id = Guid.Parse("CF459B57-361A-423B-B99E-8CE2E2537FD9"), Description = "Assets Ultimate Comercial Web", WorkStations = 0 },
                new Module() { Id = Guid.Parse("CEE6AE90-BB91-40DF-BF9A-9573837E3CD3"), Description = "Assets Ultimate Taller Web", WorkStations = 0 },
                new Module() { Id = Guid.Parse("05FDE10B-8B93-4BC6-B7EF-986AD3EB88E9"), Description = "Assets Ultimate Comunicaciones Web", WorkStations = 0 },
                new Module() { Id = Guid.Parse("CB19446E-E8E8-4B48-A96E-9ABE911100AB"), Description = "Corporativo", WorkStations = 1 },
                new Module() { Id = Guid.Parse("6091D765-931B-4677-8E53-9B0A07AC26DF"), Description = "Punto de Ventas", WorkStations = 1 },
                new Module() { Id = Guid.Parse("A60DA322-086D-44B0-86C7-9DDAC44A9143"), Description = "Assets Ultimate Corporativo Web 2.0", WorkStations = 0 },
                new Module() { Id = Guid.Parse("5F174A4F-EC24-48AC-B3E2-BBF6496DCD53"), Description = "Inventario", WorkStations = 9 },
                new Module() { Id = Guid.Parse("64A8B9EF-D584-4079-BBD1-D94418CDEE46"), Description = "Utiles y Herramientas", WorkStations = 3 },
                new Module() { Id = Guid.Parse("4CF45D34-6D5D-49CF-B864-E058CB314466"), Description = "Contabilidad", WorkStations = 4 },
                new Module() { Id = Guid.Parse("4B963114-8FBB-4637-BC34-E0F1E24A7AB5"), Description = "Activos Fijos", WorkStations = 3 },
            };

            context.Module.AddRange(modules);
            context.SaveChanges();
        }

        public void SeedStockTypes(clientsControlDbContext context)
        {
            if (context.StockTypes.Any())
            {
                return;
            }

            var stockTypes = new[] {
                new StockType { Id = Guid.Parse("0DDF6EDA-B0FA-45FE-8D94-26A4381755D3"), Description = "Comercial", WorkStations = 0},
                new StockType { Id = Guid.Parse("26448DC1-2E7C-4DE6-AB22-426B4529428C"), Description = "Light", WorkStations = 0},
                new StockType { Id = Guid.Parse("0E8E2C4C-E3D0-4A64-9969-7B6E33BF3925"), Description = "Full", WorkStations = 0},
                new StockType { Id = Guid.Parse("968079F2-89F8-41BD-BDF2-879E82F75908"), Description = "Produccion", WorkStations = 0},
                new StockType { Id = Guid.Parse("3684D98B-B54A-4015-AA8B-BC19FC3AB735"), Description = "Taller", WorkStations = 0},
            };

            context.StockTypes.AddRange(stockTypes);

            context.SaveChanges();
        }
       
        public void SeedEverything(clientsControlDbContext context)
        {
            context.Database.EnsureCreated();
            SeedConfiguration(context);
            SeedAssetsVersoin(context);
            SeedModules(context);            
        }

    }
}
