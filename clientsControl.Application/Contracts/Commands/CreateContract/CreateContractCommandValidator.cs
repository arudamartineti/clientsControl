using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Application.Contracts.Commands.CreateContract
{
    public class CreateContractCommandValidator : AbstractValidator<CreateContractCommand>
    {
        public CreateContractCommandValidator()
        {
            RuleFor(c => c.ClientId).NotEmpty().NotEqual(Guid.Empty);
            RuleFor(c => c.Numero).NotEmpty();            
        }
    }
}
