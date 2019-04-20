using clientsControl.Application.StockTypes.Queries.GetAllStockTypes;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Application.StockTypes.Queries.GetStockType
{
    public class GetStockTypeQuery : IRequest<StockTypeDto>
    {
        public Guid Id { set; get; }
    }
}
