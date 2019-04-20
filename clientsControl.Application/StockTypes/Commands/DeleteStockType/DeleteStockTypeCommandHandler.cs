using clientsControl.Application.Exceptions;
using clientsControl.Domain.Entities;
using clientsControl.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace clientsControl.Application.StockTypes.Commands.DeleteStockType
{
    public class DeleteStockTypeCommandHandler : IRequestHandler<DeleteStockTypeCommand>
    {

        private clientsControlDbContext db;

        public DeleteStockTypeCommandHandler(clientsControlDbContext db)
        {
            this.db = db;
        }

        public async Task<Unit> Handle(DeleteStockTypeCommand request, CancellationToken cancellationToken)
        {
            var ent = await db.StockTypes.FindAsync(request.Id);

            if (ent == null)
                throw new NotFoundException(nameof(StockType), request.Id);

            db.StockTypes.Remove(ent);

            await db.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
