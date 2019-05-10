using clientsControl.Application.Exceptions;
using clientsControl.Domain.Entities;
using clientsControl.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace clientsControl.Application.Contracts.Commands.DeleteContract
{
    public class DeleteContractCommandHandler : IRequestHandler<DeleteContractCommand>
    {
        private clientsControlDbContext db;

        public DeleteContractCommandHandler(clientsControlDbContext db)
        {
            this.db = db;
        }

        public async Task<Unit> Handle(DeleteContractCommand request, CancellationToken cancellationToken)
        {
            var contract = db.Contracts.Find(request.Id);

            if (contract == null)
                throw new NotFoundException(nameof(Contract), request.Id);

            db.Contracts.Remove(contract);
            await db.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
