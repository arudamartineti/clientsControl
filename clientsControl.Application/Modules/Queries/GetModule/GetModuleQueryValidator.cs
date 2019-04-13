using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Application.Modules.Queries.GetModule
{
    public class GetModuleQueryValidator : AbstractValidator<GetModuleQuery>
    {
        public GetModuleQueryValidator()
        {
            RuleFor(c => c.Id).NotEmpty().NotEqual(Guid.Empty);
        }
    }
}
