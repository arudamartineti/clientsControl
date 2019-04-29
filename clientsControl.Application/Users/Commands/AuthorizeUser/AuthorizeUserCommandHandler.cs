using clientsControl.Application.Exceptions;
using clientsControl.Domain.Entities;
using clientsControl.Persistence;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace clientsControl.Application.Users.Commands.AuthorizeUser
{
    public class AuthorizeUserCommandHandler : IRequestHandler<AuthorizeUserCommand>
    {
        private UserManager<ApplicationUser> userManager { get; set; }
        private clientsControlDbContext db { get; set; }

        public AuthorizeUserCommandHandler(UserManager<ApplicationUser> userManager, clientsControlDbContext db)
        {
            this.userManager = userManager;
            this.db = db;
        }

        public async Task<Unit> Handle(AuthorizeUserCommand request, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByIdAsync(request.Id);

            if (user == null)
                throw new NotFoundException(nameof(ApplicationUser), request.Id);

            user.ComercialAuthorized = true;

            await userManager.UpdateAsync(user);

            return Unit.Value;
        }
    }
}
