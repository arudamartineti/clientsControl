using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Application.Contracts.Commands.DeleteContract
{
    public class DeleteContractCommandValidator : AbstractValidator<DeleteContractCommand>
    {
        public DeleteContractCommandValidator()
        {
            RuleFor(c => c.Id).NotEmpty().NotEqual(Guid.Empty);
        }
    }
}
