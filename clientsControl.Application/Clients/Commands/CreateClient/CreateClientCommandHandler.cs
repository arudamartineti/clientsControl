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

namespace clientsControl.Application.Clients.Commands.CreateClient
{
    public class CreateClientCommandHandler : IRequestHandler<CreateClientCommand, CreateClientCreated>//IRequestHandler<CreateClientCommand, Unit>
    {
        clientsControlDbContext db;
        IMediator mediator;

        public CreateClientCommandHandler(clientsControlDbContext db, IMediator mediator)
        {
            this.db = db;
            this.mediator = mediator;
        }

        public async Task<CreateClientCreated> Handle(CreateClientCommand request, CancellationToken cancellationToken)
        {
            if (db.Clients.Where(c => c.Code == request.Code).Any())
                throw new CodeUsedException(nameof(Client), request.Code);

            var ent = new Client()
            {
                Id = Guid.NewGuid(),
                Code = request.Code,
                Description = request.Description,
                Discontinued = false,
                LicenseClasifications = { new LicenseClientClasification() { Id = Guid.NewGuid(), Code = "All", Name = "Todas las Licencias del Cliente" } }
            };

            db.Clients.Add(ent);

            await db.SaveChangesAsync(cancellationToken);            

            return new CreateClientCreated() { Id = ent.Id, Code = ent.Code, Description = ent.Description };
        }

        //public async Task<Unit> Handle(CreateClientCommand request, CancellationToken cancellationToken)
        //{
        //    var ent = new Client()
        //    {
        //        Id = Guid.NewGuid(),
        //        Code = request.Code,
        //        Description = request.Description,
        //        Discontinued = false,
        //        LicenseClasifications = { new LicenseClientClasification() { Id = Guid.NewGuid(), Code = "All", Name = "Todas las Licencias del Cliente" } }
        //    };

        //    db.Clients.Add(ent);

        //    await db.SaveChangesAsync(cancellationToken);
        //    await mediator.Publish(new CreateClientCreated { Id = ent.Id, Code = ent.Code, Description = ent.Description }, cancellationToken);

        //    return Unit.Value;
        //}
    }
}
