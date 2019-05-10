using clientsControl.Application.Users.Queries.GetAllUsers;
using clientsControl.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace clientsControl.Application.Users.Queries.GetAllInstallers
{
    public class GetAllInstallersQueryHandler : IRequestHandler<GetAllInstallersQuery, IEnumerable<GetAllUsersQueryDto>>
    {
        private UserManager<ApplicationUser> userManager { get; set; }
        private RoleManager<IdentityRole> roleManager { get; set; }

        public GetAllInstallersQueryHandler(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public async Task<IEnumerable<GetAllUsersQueryDto>> Handle(GetAllInstallersQuery request, CancellationToken cancellationToken)
        {
            var users = await userManager.GetUsersInRoleAsync("Instalador");

            var qry = 
               from user in users                
               select new GetAllUsersQueryDto()
               {
                   Id = user.Id,
                   Email = user.Email,
                   ClientReup = user.ClientReup,
                   ClientUser = user.ClientUser,
                   FullName = user.FullName,
                   PhoneNumber = user.PhoneNumber,
                   Username = user.UserName,
                   Authorized = user.ComercialAuthorized
               };

            return qry.AsEnumerable<GetAllUsersQueryDto>();
        }
    }
}
