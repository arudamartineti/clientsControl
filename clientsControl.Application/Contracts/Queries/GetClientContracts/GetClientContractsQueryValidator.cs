using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Application.Contracts.Queries.GetClientContracts
{
    public class GetClientContractsQueryValidator : AbstractValidator<GetClientContractsQuery>
    {
        public GetClientContractsQueryValidator()
        {
            RuleFor(c => c.Id).NotEmpty().NotEqual(Guid.Empty);
        }
    }
}
