using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Application.Contracts.Commands.DiscontinueContract
{
    public class DiscontinueContractCommandValidator : AbstractValidator<DiscontinueContractCommand>
    {
        public DiscontinueContractCommandValidator()
        {
            RuleFor(c => c.Id).NotEmpty().NotEqual(Guid.Empty);
        }
    }
}
