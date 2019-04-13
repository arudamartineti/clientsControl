using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Application.Modules.Commands.DeleteModule
{
    public class DeleteModuleCommandValidator : AbstractValidator<DeleteModuleCommand>
    {
        public DeleteModuleCommandValidator()
        {
            RuleFor(c => c.Id).NotEmpty().NotEqual(Guid.Empty);
        }
    }
}
