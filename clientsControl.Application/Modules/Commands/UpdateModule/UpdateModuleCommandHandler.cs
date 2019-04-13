using clientsControl.Application.Exceptions;
using clientsControl.Domain.Entities;
using clientsControl.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace clientsControl.Application.Modules.Commands.UpdateModule
{
    public class UpdateModuleCommandHandler : IRequestHandler<UpdateModuleCommand, UpdateModuleUpdated>
    {
        private clientsControlDbContext db;

        public UpdateModuleCommandHandler(clientsControlDbContext db)
        {
            this.db = db;
        }

        public async Task<UpdateModuleUpdated> Handle(UpdateModuleCommand request, CancellationToken cancellationToken)
        {
            var ent = await db.Module.FindAsync(request.Id);

            if (ent == null)
                throw new NotFoundException(nameof(Module), request.Id);

            ent.Description = request.Description;
            ent.WorkStations = request.WorkStations;

            await db.SaveChangesAsync(cancellationToken);

            return new UpdateModuleUpdated() { Id = ent.Id, Description = ent.Description, WorkStations = ent.WorkStations };
        }
    }
}
