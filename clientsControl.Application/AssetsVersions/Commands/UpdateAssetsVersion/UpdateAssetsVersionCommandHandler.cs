using clientsControl.Application.Exceptions;
using clientsControl.Domain.Entities;
using clientsControl.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace clientsControl.Application.AssetsVersions.Commands.UpdateAssetsVersion
{
    public class UpdateAssetsVersionCommandHandler : IRequestHandler<UpdateAssetsVersionCommand, UpdateAssetsVersionUpdated>
    {
        private clientsControlDbContext db;

        public UpdateAssetsVersionCommandHandler(clientsControlDbContext db)
        {
            this.db = db;
        }

        public async Task<UpdateAssetsVersionUpdated> Handle(UpdateAssetsVersionCommand request, CancellationToken cancellationToken)
        {
            var ent = await db.AssetsVersions.FindAsync(request.Id);

            if (ent == null)
                throw new NotFoundException(nameof(AssetsVersion), request.Id);

            ent.Description = request.Description;

            db.AssetsVersions.Update(ent);

            await db.SaveChangesAsync(cancellationToken);

            return new UpdateAssetsVersionUpdated() { Id = ent.Id, Description = ent.Description };
        }
    }
}
