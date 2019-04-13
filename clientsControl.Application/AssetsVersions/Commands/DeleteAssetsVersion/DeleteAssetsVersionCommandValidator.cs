using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Application.AssetsVersions.Commands.DeleteAssetsVersion
{
    public class DeleteAssetsVersionCommandValidator : AbstractValidator<DeleteAssetsVersionCommand>
    {
        public DeleteAssetsVersionCommandValidator()
        {
            RuleFor(c => c.Id).NotEmpty().NotEqual(Guid.Empty);
        }
    }
}
