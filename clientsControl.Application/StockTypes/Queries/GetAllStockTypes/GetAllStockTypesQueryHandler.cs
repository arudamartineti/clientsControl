using AutoMapper;
using clientsControl.Domain.Entities;
using clientsControl.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace clientsControl.Application.StockTypes.Queries.GetAllStockTypes
{
    public class GetAllStockTypesQueryHandler : IRequestHandler<GetAllStockTypesQuery, IEnumerable<StockTypeDto>>
    {
        private clientsControlDbContext db;
        private IMapper mapper;

        public GetAllStockTypesQueryHandler(clientsControlDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<StockTypeDto>> Handle(GetAllStockTypesQuery request, CancellationToken cancellationToken)
        {
            return mapper.ProjectTo<StockTypeDto>(db.StockTypes.AsQueryable<StockType>());
        }
    }
}
