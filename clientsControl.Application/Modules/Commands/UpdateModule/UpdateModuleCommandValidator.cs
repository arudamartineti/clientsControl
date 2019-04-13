using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Application.Modules.Commands.UpdateModule
{
    public class UpdateModuleCommandValidator : AbstractValidator<UpdateModuleCommand>
    {
        public UpdateModuleCommandValidator()
        {
            RuleFor(c => c.Id).NotEmpty().NotEqual(Guid.Empty);
            RuleFor(c => c.Description).NotEmpty().MaximumLength(50);
            RuleFor(c => c.WorkStations).NotEqual(0);
        }
    }
}
