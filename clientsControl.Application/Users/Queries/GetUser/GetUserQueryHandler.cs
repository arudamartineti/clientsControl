﻿using clientsControl.Application.Exceptions;
using clientsControl.Application.Users.Queries.GetAllUsers;
using clientsControl.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace clientsControl.Application.Users.Queries.GetUser
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, GetAllUsersQueryDto>
    {
        private UserManager<ApplicationUser> userManager { get; set; }
        private RoleManager<IdentityRole> roleManager { get; set; }

        public GetUserQueryHandler(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public async Task<GetAllUsersQueryDto> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByIdAsync(request.Id);            

            if (user == null)
                throw new NotFoundException(nameof(ApplicationUser), request.Id);

            var roles = await userManager.GetRolesAsync(user);

            return new GetAllUsersQueryDto()
            {
                Id = user.Id,
                Email = user.Email,
                ClientReup = user.ClientReup,
                ClientUser = user.ClientUser,
                FullName = user.FullName,
                PhoneNumber = user.PhoneNumber,
                Username = user.UserName,
                Authorized = user.ComercialAuthorized,
                Roles = (List<string>)roles
            };

        }
    }
}
