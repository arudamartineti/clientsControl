using clientsControl.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using clientsControl.Application.Exceptions;
using clientsControl.Domain.Entities;

namespace clientsControl.Application.Clients.Commands.DeleteClient
{
    public class DeleteClientCommandHandler : IRequestHandler<DeleteClientCommand>
    {
        clientsControlDbContext db;
        public DeleteClientCommandHandler(clientsControlDbContext db)
        {
            this.db = db;
        }

        public async Task<Unit> Handle(DeleteClientCommand request, CancellationToken cancellationToken)
        {
            var ent = await db.Clients.FindAsync(request.Id);

            if (ent == null)
            {
                throw new NotFoundException(nameof(Client), request.Id);
            }

            db.Clients.Remove(ent);

            await db.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
