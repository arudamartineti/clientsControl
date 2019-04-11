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

namespace clientsControl.Application.Licenses.Commands.CreateLicense
{
    public class CreateLicenseCommandHandler : IRequestHandler<CreateLicenseCommand, CreateLicenseCreated>
    {
        private clientsControlDbContext db;
        private IMediator mediator;

        public CreateLicenseCommandHandler(clientsControlDbContext db, IMediator mediator)
        {
            this.db = db;
            this.mediator = mediator;
        }

        public async Task<CreateLicenseCreated> Handle(CreateLicenseCommand request, CancellationToken cancellationToken)
        {
            if (!db.Clients.Where(c => c.Id == request.ClientId).Any())
                throw new NotFoundException(nameof(Client), request.ClientId);

            if (!db.StockTypes.Where(c => c.Id == request.StockTypeId).Any())
                throw new NotFoundException(nameof(StockType), request.StockTypeId);

            if (!db.AssetsVersions.Where(c => c.Id == request.VersionId).Any())
                throw new NotFoundException(nameof(AssetsVersion), request.VersionId);

            if (!db.LicenseClientClasification.Where(c => c.ClientId == request.ClientId && c.Code == "All").Any())
                throw new NotFoundException(nameof(LicenseClientClasification), "All");

            var licenseClientAllClasification = db.LicenseClientClasification.Where(c => c.ClientId == request.ClientId && c.Code == "All").FirstOrDefault();

            var ent = new License()
            {
                Id = Guid.NewGuid(),
                REUP = request.REUP,
                ClasificationId = licenseClientAllClasification.Id,
                ClientId = request.ClientId,
                Code = request.Code,
                CreationDate = request.CreationDate,
                Descontinued = false,
                Name = request.Name,
                StockTypeId = request.StockTypeId,
                VersionId = request.VersionId,
                LicenseNames = new List<LicenseName>() { new LicenseName() { Id = Guid.NewGuid(), Date = request.CreationDate, Name = request.Name, REUP = request.REUP } }
            };

            db.Licenses.Add(ent);
            await db.SaveChangesAsync(cancellationToken);

            return new CreateLicenseCreated()
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
