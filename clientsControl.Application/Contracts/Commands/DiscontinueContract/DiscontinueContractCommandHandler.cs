using clientsControl.Application.Exceptions;
using clientsControl.Domain.Entities;
using clientsControl.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace clientsControl.Application.Contracts.Commands.DiscontinueContract
{
    public class DiscontinueContractCommandHandler : IRequestHandler<DiscontinueContractCommand>
    {
        private clientsControlDbContext db;

        public DiscontinueContractCommandHandler(clientsControlDbContext db)
        {
            this.db = db;
        }

        public async Task<Unit> Handle(DiscontinueContractCommand request, CancellationToken cancellationToken)
        {
            var contract = db.Contracts.Find(request.Id);
            if (contract == null)
                throw new NotFoundException(nameof(Contract), request.Id);

            contract.Discontinued = true;

            await db.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
