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

namespace clientsControl.Application.Licenses.Commands.UpdateLicense
{
    public class UpdateLicenseCommandHandler : IRequestHandler<UpdateLicenseCommand, UpdateLicenseUpdated>
    {
        private clientsControlDbContext db;
        private IMediator mediator;

        public UpdateLicenseCommandHandler(clientsControlDbContext db, IMediator mediator)
        {
            this.db = db;
            this.mediator = mediator;
        }

        public async Task<UpdateLicenseUpdated> Handle(UpdateLicenseCommand request, CancellationToken cancellationToken)
        {
            if (!db.Licenses.Where(c => c.Id == request.Id).Any())
                throw new NotFoundException(nameof(License), request.Id);

            if (!db.Clients.Where(c => c.Id == request.ClientId).Any())
                throw new NotFoundException(nameof(Client), request.ClientId);

            if (!db.StockTypes.Where(c => c.Id == request.StockTypeId).Any())
                throw new NotFoundException(nameof(StockType), request.StockTypeId);

            if (!db.AssetsVersions.Where(c => c.Id == request.VersionId).Any())
                throw new NotFoundException(nameof(AssetsVersion), request.VersionId);

            if (!db.LicenseClientClasification.Where(c => c.ClientId == request.ClasificationId).Any())
                throw new NotFoundException(nameof(LicenseClientClasification), request.ClasificationId);

            var ent = db.Licenses.Where(c => c.Id == request.Id).FirstOrDefault();

            bool changeName = request.Name != ent.Name || request.REUP != ent.REUP;

            ent.ClientId = request.ClientId;
            ent.Code = request.Code;
            ent.CreationDate = request.CreationDate;
            ent.Descontinued = request.Descontinued;
            ent.Name = request.Name;
            ent.REUP = request.REUP;
            ent.StockTypeId = request.StockTypeId;
            ent.VersionId = request.VersionId;
            ent.ClasificationId = request.ClasificationId;

            db.Licenses.Update(ent);

            if (changeName) {
                db.LicenseNames.Add(new LicenseName() { Id = Guid.NewGuid(), Date = DateTime.Now, LicenseId = ent.Id, Name = request.Name, REUP = request.REUP });
            }

            await db.SaveChangesAsync();

            return new UpdateLicenseUpdated()
            {
                Id = ent.Id,
                ClientId = ent.ClientId,
                Code = ent.Code,
                CreationDate = ent.CreationDate,
                Descontinued = ent.Descontinued,
                Name = ent.Name,
                REUP = ent.REUP,
                StockTypeId = ent.StockTypeId,
                VersionId = ent.VersionId                
            };
        }
    }
}
