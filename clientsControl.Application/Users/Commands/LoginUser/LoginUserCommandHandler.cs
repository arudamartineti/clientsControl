using clientsControl.Application.Exceptions;
using clientsControl.Application.Interfaces;
using clientsControl.Domain.Entities;
using clientsControl.Persistence;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace clientsControl.Application.Users.Commands.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, object>
    {
        IIdentityManager manager;
        private SignInManager<ApplicationUser> signInManager { get; set; }
        private UserManager<ApplicationUser> userManager { get; set; }
        private clientsControlDbContext db { get; set; }

        public LoginUserCommandHandler(IIdentityManager manager, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, clientsControlDbContext db)
        {
            this.manager = manager;
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.db = db;
        }

        public async Task<object> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByNameAsync(request.Username);

            if (user == null)
                throw new NotFoundException(nameof(ApplicationUser), request.Username);

            if (!user.ComercialAuthorized)
                throw new UserNotAuthorizedException();
            
            var result = await signInManager.PasswordSignInAsync(user, request.Password, true, false);

            if (!result.Succeeded)
            {
                throw new LoginException();
            }

            return manager.buildToken(user.UserName);
        }
    }
}
