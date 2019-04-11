using clientsControl.Persistence.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Persistence
{
    public class clientsControlDbContextFactory : DesignTimeDbContextFactoryBase<clientsControlDbContext>
    {
        protected override clientsControlDbContext CreateNewInstance(DbContextOptions<clientsControlDbContext> options)
        {
            return new clientsControlDbContext(options);
        }
    }
}
