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

namespace clientsControl.Application.Contacts.Commands.UpdateContact
{
    public class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommand, UpdateContactUpdated>
    {
        private clientsControlDbContext db;
        private IMediator mediator;

        public UpdateContactCommandHandler(clientsControlDbContext db, IMediator mediator)
        {
            this.db = db;
            this.mediator = mediator;
        }
        public async Task<UpdateContactUpdated> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
        {
            if (!db.Contacts.Where(c => c.Id == request.Id).Any())
                throw new NotFoundException(nameof(Contact), request.Id);

            var ent = db.Contacts.Where(c => c.Id == request.Id).FirstOrDefault();

            ent.Name = request.Name;
            ent.PhoneNumber = request.PhoneNumber;
            ent.Email = request.Email;
            ent.ClientId = request.ClientId;

            db.Contacts.Update(ent);

            await db.SaveChangesAsync();

            return new UpdateContactUpdated() { Id = ent.Id, Email = ent.Email, Name = ent.Name, PhoneNumber = ent.PhoneNumber };
        }
    }
}
