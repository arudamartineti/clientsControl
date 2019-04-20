using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Application.StockTypes.Queries.GetAllStockTypes
{
    public class GetAllStockTypesQuery : IRequest<IEnumerable<StockTypeDto>>
    {
    }
}
