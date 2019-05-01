using clientsControl.Application.Exceptions;
using clientsControl.Application.Users.Queries.GetAllUsers;
using clientsControl.Domain.Entities;
using clientsControl.Persistence;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace clientsControl.Application.Users.Commands.RegisterUser
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, GetAllUsersQueryDto>
    {
        private UserManager<ApplicationUser> userManager { get; set; }
        private RoleManager<IdentityRole> roleManager { get; set; }
        private clientsControlDbContext db { get; set; }

        public RegisterUserCommandHandler(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, clientsControlDbContext db)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.db = db;
        }

        public async Task<GetAllUsersQueryDto> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByEmailAsync(request.Email);

            if (user != null)
                throw new UserRegisterException();

            user = new ApplicationUser() { FullName = request.FullName, Email = request.Email, UserName = request.Email, PhoneNumber = request.PhoneNumber, ClientUser = request.ClientUser, ClientReup = request.ClientReup };
            var result = await userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
                throw new UserRegisterException();

            return new GetAllUsersQueryDto() { Id = user.Id, Username = user.UserName, ClientReup = user.ClientReup, ClientUser = user.ClientUser, Email = user.Email, FullName = user.FullName, PhoneNumber = user.PhoneNumber  };
        }
    }
}
