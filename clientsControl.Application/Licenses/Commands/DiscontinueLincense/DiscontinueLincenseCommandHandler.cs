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

namespace clientsControl.Application.Licenses.Commands.DiscontinueLincense
{
    public class DiscontinueLincenseCommandHandler : IRequestHandler<DiscontinueLincenseCommand>
    {
        private clientsControlDbContext db;
        private IMediator mediator;

        public DiscontinueLincenseCommandHandler(clientsControlDbContext db, IMediator mediator)
        {
            this.db = db;
            this.mediator = mediator;
        }

        public async Task<Unit> Handle(DiscontinueLincenseCommand request, CancellationToken cancellationToken)
        {
            if (!db.Licenses.Where(c => c.Id == request.Id).Any())
                throw new NotFoundException(nameof(License), request.Id);

            var ent = db.Licenses.Where(c => c.Id == request.Id).FirstOrDefault();

            ent.Descontinued = true;
            db.Licenses.Update(ent);

            await db.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
