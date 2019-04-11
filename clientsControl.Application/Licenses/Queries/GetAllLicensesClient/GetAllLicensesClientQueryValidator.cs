using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Application.Licenses.Queries.GetAllLicensesClient
{
    public class GetAllLicensesClientQueryValidator : AbstractValidator<GetAllLicensesClientQuery>
    {
        public GetAllLicensesClientQueryValidator()
        {
            RuleFor(c => c.Id).NotEmpty().NotEqual(Guid.Empty);
        }
    }
}
