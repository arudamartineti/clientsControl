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

namespace clientsControl.Application.Contacts.Commands.CreateContact
{
    public class CreateContactCommandHandler : IRequestHandler<CreateContactCommand, CreateContactCreated>
    {
        private clientsControlDbContext db;
        private IMediator mediator;

        public CreateContactCommandHandler(clientsControlDbContext db, IMediator mediator)
        {
            this.db = db;
            this.mediator = mediator;
        }
        

        public async Task<CreateContactCreated> Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {
            if (!db.Clients.Where(c => c.Id == request.ClientId).Any())
                throw new NotFoundException(nameof(Client), request.ClientId);

            var ent = new Contact()
            {
                Id = Guid.NewGuid(), 
                Name = request.Name,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                ClientId = request.ClientId,
                RecibeLicencias = request.RecibeLicencias,
                LicenseId = request.LicenseId
            };

            db.Contacts.Add(ent);
            await db.SaveChangesAsync(cancellationToken);

            return new CreateContactCreated() { Id = ent.Id, Email = ent.Email, Name = ent.Name, PhoneNumber = ent.PhoneNumber };

        }
    }
}
