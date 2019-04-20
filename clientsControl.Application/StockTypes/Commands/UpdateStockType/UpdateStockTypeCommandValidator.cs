using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Application.StockTypes.Commands.UpdateStockType
{
    public class UpdateStockTypeCommandValidator : AbstractValidator<UpdateStockTypeCommand>
    {
        public UpdateStockTypeCommandValidator()
        {
            RuleFor(c => c.Id).NotEmpty().NotEqual(Guid.Empty);
            RuleFor(c => c.Description).NotEmpty().MaximumLength(50);
            RuleFor(c => c.WorkStations).NotEqual(0);

        }
    }
}
