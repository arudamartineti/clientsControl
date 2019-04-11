using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Application.Licenses.Commands.DeleteLicense
{
    public class DeleteLicenseCommandValidator : AbstractValidator<DeleteLicenseCommand>
    {
        public DeleteLicenseCommandValidator()
        {
            RuleFor(c => c.Id).NotEmpty().NotEqual(Guid.Empty);
        }
    }
}
