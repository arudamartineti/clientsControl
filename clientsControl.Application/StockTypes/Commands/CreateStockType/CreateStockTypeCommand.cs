using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Application.StockTypes.Commands.CreateStockType
{
    public class CreateStockTypeCommand : IRequest<CreateStockTypeCreated>
    {
        public string Description { get; set; }
        public int WorkStations { get; set; }
    }
}
