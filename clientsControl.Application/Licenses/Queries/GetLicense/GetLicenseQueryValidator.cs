using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Application.Licenses.Queries.GetLicense
{
    public class GetLicenseQueryValidator : AbstractValidator<GetLicenseQuery>
    {
        public GetLicenseQueryValidator()
        {
            RuleFor(c => c.Id).NotEmpty().NotEqual(Guid.Empty);
        }
    }
}
