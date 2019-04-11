using clientsControl.Application.Exceptions;
using clientsControl.Domain.Entities;
using clientsControl.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace clientsControl.Application.Clients.Commands.DescontinueClient
{
    public class DescontinueClientCommandHandler : IRequestHandler<DescontinueClientCommand>
    {
        private clientsControlDbContext db;
        private IMediator mediator;

        public DescontinueClientCommandHandler(clientsControlDbContext db, IMediator mediator)
        {
            this.db = db;
            this.mediator = mediator;
        }
        public async Task<Unit> Handle(DescontinueClientCommand request, CancellationToken cancellationToken)
        {
            if (!db.Clients.Where(c => c.Id == request.Id).Any())
                throw new NotFoundException(nameof(Client), request.Id);

            var ent = db.Clients.Where(c => c.Id == request.Id).FirstOrDefault();

            ent.Discontinued = true;

            await db.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
