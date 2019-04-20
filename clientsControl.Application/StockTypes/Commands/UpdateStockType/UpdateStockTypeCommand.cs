using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Application.StockTypes.Commands.UpdateStockType
{
    public class UpdateStockTypeCommand : IRequest<UpdateStockTypeUpdated>
    {
        public Guid Id { set; get; }
        public string Description { get; set; }
        public int WorkStations { get; set; }
    }
}
