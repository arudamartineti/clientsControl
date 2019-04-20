using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Application.StockTypes.Commands.DeleteStockType
{
    public class DeleteStockTypeCommand : IRequest
    {
        public Guid Id { set; get; }
    }
}
