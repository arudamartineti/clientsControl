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

namespace clientsControl.Application.Modules.Commands.CreateModule
{
    public class CreateModuleCommandHandler : IRequestHandler<CreateModuleCommand, CreateModuleCreated>
    {
        private clientsControlDbContext db;

        public CreateModuleCommandHandler(clientsControlDbContext db)
        {
            this.db = db;
        }

        public async Task<CreateModuleCreated> Handle(CreateModuleCommand request, CancellationToken cancellationToken)
        {
            if (db.Module.Where(c => c.Description == request.Description).Any())
                throw new DescriptionUsedException(nameof(Module), request.Description);

            var ent = new Module() { Id =  Guid.NewGuid(), Description = request.Description, WorkStations = request.WorkStations };

            db.Module.Add(ent);
            await db.SaveChangesAsync();

            return new CreateModuleCreated() { Id = ent.Id, Description = ent.Description, WorkStations = ent.WorkStations };
        }
    }
}
