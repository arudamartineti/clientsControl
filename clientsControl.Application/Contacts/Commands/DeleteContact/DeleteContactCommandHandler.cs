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

namespace clientsControl.Application.Contacts.Commands.DeleteContact
{
    public class DeleteContactCommandHandler : IRequestHandler<DeleteContactCommand>
    {
        private clientsControlDbContext db;
        private IMediator mediator;

        public DeleteContactCommandHandler(clientsControlDbContext db, IMediator mediator)
        {
            this.db = db;
            this.mediator = mediator;
        }

        public async Task<Unit> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
        {
            if (!db.Contacts.Where(c => c.Id == request.Id).Any())
                throw new NotFoundException(nameof(Contact), request.Id);

            var ent = db.Contacts.Where(c => c.Id == request.Id).FirstOrDefault();

            db.Contacts.Remove(ent);

            await db.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
