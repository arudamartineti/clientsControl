using AutoMapper;
using clientsControl.Domain.Entities;
using clientsControl.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace clientsControl.Application.StockTypes.Commands.CreateStockType
{
    public class CreateStockTypeCommandHandler : IRequestHandler<CreateStockTypeCommand, CreateStockTypeCreated>
    {
        private clientsControlDbContext db;
        private IMapper mapper;

        public CreateStockTypeCommandHandler(clientsControlDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<CreateStockTypeCreated> Handle(CreateStockTypeCommand request, CancellationToken cancellationToken)
        {
            var ent = new StockType() { Id = Guid.NewGuid(), Description = request.Description, WorkStations = request.WorkStations };

            await db.StockTypes.AddAsync(ent, cancellationToken);
            await db.SaveChangesAsync(cancellationToken);

            return mapper.Map<CreateStockTypeCreated>(ent);
        }
    }
}
