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

namespace clientsControl.Application.AssetsVersions.Commands.CreateAssetsVersion
{
    public class CreateAssetsVersionCommandHandler : IRequestHandler<CreateAssetsVersionCommand, CreateAssetsVersionCreated>
    {
        private clientsControlDbContext db;

        public CreateAssetsVersionCommandHandler(clientsControlDbContext db)
        {
            this.db = db;
        }

        public async Task<CreateAssetsVersionCreated> Handle(CreateAssetsVersionCommand request, CancellationToken cancellationToken)
        {
            if (db.AssetsVersions.Where(c => c.Description == request.Description).Any())
                throw new CodeUsedException(nameof(AssetsVersions), request.Description);

            var ent = new AssetsVersion() { Id = Guid.NewGuid(), Description = request.Description };

            db.AssetsVersions.Add(ent);

            await db.SaveChangesAsync();

            return new CreateAssetsVersionCreated() { Id = ent.Id, Description = ent.Description };
        }
    }
}
