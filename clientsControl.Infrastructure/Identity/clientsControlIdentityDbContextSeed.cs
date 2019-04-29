using clientsControl.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace clientsControl.Infrastructure.Identity
{
    public static class clientsControlIdentityDbContextSeed
    {
        //public async Task SeedUsersAsync(UserManager<ApplicationUser> userManager)
        //{
        //    var defaultUser = new ApplicationUser { UserName = "denny@enpses.co.cu", Email = "denny@enpses.co.cu" };
        //    await userManager.CreateAsync(defaultUser, "admin123");

        //    await userManager.AddToRoleAsync(defaultUser, "Administrador");

        //    //return Task.CompletedTask();
        //}

        public static async void SeedRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            var roles = new[] {
                    "Administrador", 
                    "Comercial", "Comercial - Solo lectura",
                    "Contratación", "Contratación - Solo lectura",
                    "Instalador", "Instalador - Solo lectura",
                    "Soporte", "Soporte - Solo lectura",
                    "Reportes", "Reportes - Solo lectura",
                    "Cliente"                    
            };

            foreach (string role in roles)
            {
                bool roleExists = await roleManager.RoleExistsAsync(role);
                IdentityResult result;

                if (!roleExists)
                {
                    result = await roleManager.CreateAsync(new IdentityRole(role));

                    if (result.Succeeded)
                    {
                    }
                }
            }

        }
    }
}
