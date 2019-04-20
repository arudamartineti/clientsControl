using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Application.StockTypes.Queries.GetStockType
{
    public class GetStockTypeQueryValidator : AbstractValidator<GetStockTypeQuery>
    {
        public GetStockTypeQueryValidator()
        {
            RuleFor(c => c.Id).NotEmpty().NotEqual(Guid.Empty);
        }
    }
}
