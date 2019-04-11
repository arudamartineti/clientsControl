using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Application.AssetsVersions.Commands.CreateAssetsVersion
{
    public class CreateAssetsVersionCommandValidator : AbstractValidator<CreateAssetsVersionCommand>
    {
        public CreateAssetsVersionCommandValidator()
        {
            RuleFor(c => c.Description).NotEmpty().MaximumLength(50);
        }
    }
}
