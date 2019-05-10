using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Application.Contracts.Queries.GetContract
{
    public class GetContractQueryValidator : AbstractValidator<GetContractQuery>
    {
        public GetContractQueryValidator()
        {
            RuleFor(c => c.Id).NotEmpty().NotEqual(Guid.Empty);
        }
    }
}
