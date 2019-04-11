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

        public void SeedEverything(clientsControlDbContext context)
        {
            context.Database.EnsureCreated();

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
        }

    }
}
