using clientsControl.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace clientsControl.Application.Users.Queries.GetAllRoles
{
    public class GetAllRolesQueryHandler : IRequestHandler<GetAllRolesQuery, IEnumerable<IdentityRole>>
    {
        private UserManager<ApplicationUser> userManager { get; set; }
        private RoleManager<IdentityRole> roleManager { get; set; }

        public GetAllRolesQueryHandler(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public async Task<IEnumerable<IdentityRole>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
        {
            return roleManager.Roles;
            //var qry =
            //    from r in roleManager.Roles
            //    select new GetAllRolesQueryDto()
            //    {
            //        Id = r.Id,
            //        Name = r.Name
            //    };

            //return qry;
        }
    }
}
