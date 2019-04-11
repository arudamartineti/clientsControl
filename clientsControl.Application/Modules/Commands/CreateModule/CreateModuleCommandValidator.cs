using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Application.Modules.Commands.CreateModule
{
    public class CreateModuleCommandValidator : AbstractValidator<CreateModuleCommand>
    {
        public CreateModuleCommandValidator()
        {
            RuleFor(c => c.Description).NotEmpty().MaximumLength(50);
            RuleFor(c => c.WorkStations).LessThan(200);
        }
    }
}
