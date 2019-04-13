using clientsControl.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using clientsControl.Application.Exceptions;
using clientsControl.Domain.Entities;

namespace clientsControl.Application.Clients.Commands.UpdateClient
{
    public class UpdateClientCommandHandler : IRequestHandler<UpdateClientCommand, UpdateClientUpdated>
    {
        clientsControlDbContext db;
        IMediator mediator;
        public UpdateClientCommandHandler(clientsControlDbContext db, IMediator mediator)
        {
            this.db = db;
            this.mediator = mediator;
        }

        public async Task<UpdateClientUpdated> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
        {
            var ent = await db.Clients.FindAsync(request.Id);

            if (ent == null) {
                throw new NotFoundException(nameof(Client), request.Id);
            }

            if (db.Clients.Where(c => c.Id != request.Id && c.Code == request.Code).Any())
                throw new CodeUsedException(nameof(Client), request.Code);

            ent.Code = request.Code;
            ent.Description = request.Description;

            db.Clients.Update(ent);

            await db.SaveChangesAsync();

            return new UpdateClientUpdated() { Id = ent.Id, Code = ent.Code, Description = ent.Description };
        }
    }
}
