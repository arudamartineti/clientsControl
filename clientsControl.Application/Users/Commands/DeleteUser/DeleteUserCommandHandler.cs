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

namespace clientsControl.Application.Users.Commands.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
    {
        private UserManager<ApplicationUser> userManager { get; set; }        
        private clientsControlDbContext db { get; set; }

        public DeleteUserCommandHandler(UserManager<ApplicationUser> userManager, clientsControlDbContext db)
        {
            this.userManager = userManager;
            this.db = db;
        }

        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByIdAsync(request.Id);

            if (user == null)
                throw new NotFoundException(nameof(ApplicationUser), request.Id);

            await userManager.DeleteAsync(user);
            
            return Unit.Value;
        }
    }
}
