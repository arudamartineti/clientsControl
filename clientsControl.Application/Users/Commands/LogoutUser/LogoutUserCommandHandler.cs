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

namespace clientsControl.Application.Users.Commands.LogoutUser
{
    public class LogoutUserCommandHandler : IRequestHandler<LogoutUserCommand>
    {
        IIdentityManager manager;
        private SignInManager<ApplicationUser> signInManager { get; set; }
        private UserManager<ApplicationUser> userManager { get; set; }
        private clientsControlDbContext db { get; set; }

        public LogoutUserCommandHandler(IIdentityManager manager, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, clientsControlDbContext db)
        {
            this.manager = manager;
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.db = db;
        }

        public async Task<Unit> Handle(LogoutUserCommand request, CancellationToken cancellationToken)
        {
            await signInManager.SignOutAsync();
            return Unit.Value;
        }
    }
}
