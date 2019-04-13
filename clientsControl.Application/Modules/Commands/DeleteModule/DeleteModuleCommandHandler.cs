using clientsControl.Application.Exceptions;
using clientsControl.Domain.Entities;
using clientsControl.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace clientsControl.Application.Modules.Commands.DeleteModule
{
    public class DeleteModuleCommandHandler : IRequestHandler<DeleteModuleCommand>
    {
        private clientsControlDbContext db;

        public DeleteModuleCommandHandler(clientsControlDbContext db)
        {
            this.db = db;
        }

        public async Task<Unit> Handle(DeleteModuleCommand request, CancellationToken cancellationToken)
        {
            var ent = await db.Module.FindAsync(request.Id);

            if (ent == null)
                throw new NotFoundException(nameof(Module), request.Id);

            db.Module.Remove(ent);

            await db.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
