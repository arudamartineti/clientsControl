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

namespace clientsControl.Application.Licenses.Commands.DeleteLicense
{
    public class DeleteLicenseCommandHandler : IRequestHandler<DeleteLicenseCommand>
    {
        private clientsControlDbContext db;
        private IMediator mediator;

        public DeleteLicenseCommandHandler(clientsControlDbContext db, IMediator mediator)
        {
            this.db = db;
            this.mediator = mediator;
        }

        public async Task<Unit> Handle(DeleteLicenseCommand request, CancellationToken cancellationToken)
        {
            if (!db.Licenses.Where(c => c.Id == request.Id).Any())
                throw new NotFoundException(nameof(License), request.Id);

            var ent = db.Licenses.Where(c => c.Id == request.Id).FirstOrDefault();

            db.Licenses.Remove(ent);

            await db.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
