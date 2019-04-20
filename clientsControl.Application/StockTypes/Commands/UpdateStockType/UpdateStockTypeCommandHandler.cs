using AutoMapper;
using clientsControl.Application.Exceptions;
using clientsControl.Domain.Entities;
using clientsControl.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace clientsControl.Application.StockTypes.Commands.UpdateStockType
{
    public class UpdateStockTypeCommandHandler : IRequestHandler<UpdateStockTypeCommand, UpdateStockTypeUpdated>
    {
        private clientsControlDbContext db;
        private IMapper mapper;

        public UpdateStockTypeCommandHandler(clientsControlDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<UpdateStockTypeUpdated> Handle(UpdateStockTypeCommand request, CancellationToken cancellationToken)
        {
            var ent = await db.StockTypes.FindAsync(request.Id);

            if (ent == null)
                throw new NotFoundException(nameof(StockType), request.Id);

            ent.Description = request.Description;
            ent.WorkStations = request.WorkStations;

            db.StockTypes.Update(ent);

            await db.SaveChangesAsync(cancellationToken);

            return mapper.Map<UpdateStockTypeUpdated>(ent);
        }
    }
}
