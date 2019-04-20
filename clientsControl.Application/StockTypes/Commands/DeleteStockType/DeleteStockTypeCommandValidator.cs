using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Application.StockTypes.Commands.DeleteStockType
{
    public class DeleteStockTypeCommandValidator : AbstractValidator<DeleteStockTypeCommand>
    {
        public DeleteStockTypeCommandValidator()
        {
            RuleFor(c => c.Id).NotEmpty().NotEqual(Guid.Empty);
        }
    }
}
