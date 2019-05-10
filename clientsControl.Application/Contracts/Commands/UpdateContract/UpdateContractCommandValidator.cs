using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Application.Contracts.Commands.UpdateContract
{
    public class UpdateContractCommandValidator : AbstractValidator<UpdateContractCommand>
    {
        public UpdateContractCommandValidator()
        {
            RuleFor(c => c.Id).NotEmpty().NotEqual(Guid.Empty);
            RuleFor(c => c.ClientId).NotEmpty().NotEqual(Guid.Empty);
            RuleFor(c => c.Numero).NotEmpty();
        }
    }
}
