using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Application.LicenseClientsClasifications.Queries
{
    public class GetLicenseClasificationsClientQueryValidator : AbstractValidator<GetLicenseClasificationsClientQuery>
    {
        public GetLicenseClasificationsClientQueryValidator()
        {
            RuleFor(c => c.Id).NotEmpty().NotEqual(Guid.Empty);
        }
    }
}
