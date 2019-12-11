using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using clientsControl.Domain.Entities;
using clientsControl.Infrastructure.Identity;
using clientsControl.Persistence;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace clientsControl.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CreateWebHostBuilder(args).Build().Run();

            var host = CreateWebHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                try
                {
                    var context = scope.ServiceProvider.GetService<clientsControlDbContext>();
                    context.Database.Migrate();

                    clientsControlInitializer.Initialize(context);

                    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                    //clientsControlIdentityDbContextSeed.SeedRolesAsync(roleManager);

                    /* poblando roles */

                    var roles = new[] {
                    "Administrador",
                    "Comercial", "Comercial - Solo lectura",
                    "Contrataci�n", "Contrataci�n - Solo lectura",
                    "Instalador", "Instalador - Solo lectura",
                    "Soporte", "Soporte - Solo lectura",
                    "Reportes", "Reportes - Solo lectura",
                    "Cliente"
                    };

                    foreach (string role in roles)
                    {
                        Task<bool> roleExists = roleManager.RoleExistsAsync(role);                        

                        if (!roleExists.Result)
                        {
                            Task<IdentityResult> result = roleManager.CreateAsync(new IdentityRole(role));

                            if (result.Result.Succeeded)
                            {
                            }
                        }
                    }

                    /*fin poblando roles */

                    /* poblando usuarios */

                    var defaultUser = new ApplicationUser { UserName = "admin@enpses.co.cu", Email = "admin@enpses.co.cu", FullName = "Administrador del M�dulo", ComercialAuthorized = true  };
                    IdentityResult resultUser = userManager.CreateAsync(defaultUser, "Admin123*-+").Result;

                    if (resultUser.Succeeded)
                    {
                        userManager.AddToRoleAsync(defaultUser,"Administrador").Wait();
                    }
                   

                    /* fin poblando usuarios */

                    //seeder.SeedUsersAsync(userManager);


                }
                catch (Exception ex)
                {
                    var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while migrating or initializing the database.");
                }
            }

            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
