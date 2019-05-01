using clientsControl.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace clientsControl.Application.Users.Queries.GetAllUsers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<GetAllUsersQueryDto>>
    {
        private UserManager<ApplicationUser> userManager { get; set; }
        private RoleManager<IdentityRole> roleManager { get; set; }

        public GetAllUsersQueryHandler(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public async Task<IEnumerable<GetAllUsersQueryDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var qry =
                from user in userManager.Users                
                select new GetAllUsersQueryDto()
                {
                    Id = user.Id,
                    Email = user.Email,
                    ClientReup = user.ClientReup,
                    ClientUser = user.ClientUser,
                    FullName = user.FullName,
                    PhoneNumber = user.PhoneNumber,
                    UserName = user.UserName,
                    Authorized = user.ComercialAuthorized
                };

            return qry.AsEnumerable<GetAllUsersQueryDto>();
        }
    }
}
