using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Application.Licenses.Commands.CreateLicense
{
    public class CreateLicenseCommandValidator : AbstractValidator<CreateLicenseCommand>
    {
        public CreateLicenseCommandValidator()
        {
            RuleFor(c => c.Code).NotEmpty();
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.REUP).NotEmpty();
            RuleFor(c => c.CreationDate).NotEmpty();
            RuleFor(c => c.VersionId).NotEmpty().NotEqual(Guid.Empty);
            RuleFor(c => c.StockTypeId).NotEmpty().NotEqual(Guid.Empty);
            RuleFor(c => c.ClientId).NotEmpty().NotEqual(Guid.Empty);
        }
    }
}
