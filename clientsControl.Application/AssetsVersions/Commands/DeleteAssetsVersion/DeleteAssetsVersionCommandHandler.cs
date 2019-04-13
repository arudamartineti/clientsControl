using clientsControl.Application.Exceptions;
using clientsControl.Domain.Entities;
using clientsControl.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace clientsControl.Application.AssetsVersions.Commands.DeleteAssetsVersion
{
    public class DeleteAssetsVersionCommandHandler : IRequestHandler<DeleteAssetsVersionCommand>
    {
        private clientsControlDbContext db;

        public DeleteAssetsVersionCommandHandler(clientsControlDbContext db)
        {
            this.db = db;
        }

        public async Task<Unit> Handle(DeleteAssetsVersionCommand request, CancellationToken cancellationToken)
        {
            var ent = await db.AssetsVersions.FindAsync(request.Id);

            if (ent == null)
                throw new NotFoundException(nameof(AssetsVersion), request.Id);

            db.Remove(ent);
            await db.SaveChangesAsync();
            
            return Unit.Value;
        }
    }
}
