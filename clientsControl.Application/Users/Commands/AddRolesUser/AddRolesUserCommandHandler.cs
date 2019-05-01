using clientsControl.Application.Exceptions;
using clientsControl.Application.Users.Queries.GetAllUsers;
using clientsControl.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace clientsControl.Application.Users.Commands.AddRolesUser
{
    public class AddRolesUserCommandHandler : IRequestHandler<AddRolesUserCommand, GetAllUsersQueryDto>
    {
        private UserManager<ApplicationUser> userManager { get; set; }
        private RoleManager<IdentityRole> roleManager { get; set; }

        public AddRolesUserCommandHandler(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public async Task<GetAllUsersQueryDto> Handle(AddRolesUserCommand request, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByIdAsync(request.Id);

            if (user == null)
                throw new NotFoundException(nameof(ApplicationUser), request.Id);

            //var result = await userManager.AddToRolesAsync(user, request.Roles);

            //if (result.Succeeded)
            //{
            //}

            foreach (string role in request.Roles)
            {
                var result = await userManager.AddToRoleAsync(user, role);

                if (result.Succeeded)
                {
                }
            }

            var roles = await userManager.GetRolesAsync(user);

            return new GetAllUsersQueryDto()
            {
                Id = user.Id,
                Email = user.Email,
                ClientReup = user.ClientReup,
                ClientUser = user.ClientUser,
                FullName = user.FullName,
                PhoneNumber = user.PhoneNumber,
                UserName = user.UserName,
                Authorized = user.ComercialAuthorized,
                Roles = (List<string>)roles
            };

            //throw new NotImplementedException();
        }
    }
}
