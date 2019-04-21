using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Application.Licenses.Queries.GetAllLicenseClientSelect
{
    public class GetAllLicenseClientSelectQueryValidator : AbstractValidator<GetAllLicenseClientSelectQuery>
    {
        public GetAllLicenseClientSelectQueryValidator()
        {
            RuleFor(c => c.Id).NotEmpty().NotEqual(Guid.Empty);
        }
    }
}
