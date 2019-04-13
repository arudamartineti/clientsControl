using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Application.AssetsVersions.Commands.UpdateAssetsVersion
{
    public class UpdateAssetsVersionCommandValidator : AbstractValidator<UpdateAssetsVersionCommand>
    {
        public UpdateAssetsVersionCommandValidator()
        {
            RuleFor(c => c.Id).NotEmpty().NotEqual(Guid.Empty);
            RuleFor(c => c.Description).NotEmpty().MaximumLength(50);
        }
    }
}
