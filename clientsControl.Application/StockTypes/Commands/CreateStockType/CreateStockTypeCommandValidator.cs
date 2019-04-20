using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Application.StockTypes.Commands.CreateStockType
{
    public class CreateStockTypeCommandValidator : AbstractValidator<CreateStockTypeCommand>
    {
        public CreateStockTypeCommandValidator()
        {
            RuleFor(c => c.Description).NotEmpty().MaximumLength(50);
            RuleFor(c => c.WorkStations).NotEqual(0);
        }
    }
}
