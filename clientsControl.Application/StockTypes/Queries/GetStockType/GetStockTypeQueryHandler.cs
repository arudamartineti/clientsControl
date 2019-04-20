using AutoMapper;
using clientsControl.Application.Exceptions;
using clientsControl.Application.StockTypes.Queries.GetAllStockTypes;
using clientsControl.Domain.Entities;
using clientsControl.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace clientsControl.Application.StockTypes.Queries.GetStockType
{
    public class GetStockTypeQueryHandler : IRequestHandler<GetStockTypeQuery, StockTypeDto>
    {
        private clientsControlDbContext db;
        private IMapper mapper;

        public GetStockTypeQueryHandler(clientsControlDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<StockTypeDto> Handle(GetStockTypeQuery request, CancellationToken cancellationToken)
        {
            var ent = await db.StockTypes.FindAsync(request.Id);

            if (ent == null)
                throw new NotFoundException(nameof(StockType), request.Id);

            return mapper.Map<StockTypeDto>(ent);

        }
    }
}
