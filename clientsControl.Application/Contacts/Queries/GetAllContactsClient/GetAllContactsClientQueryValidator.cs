using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Application.Contacts.Queries.GetAllContactsClient
{
    public class GetAllContactsClientQueryValidator : AbstractValidator<GetAllContactsClientQuery>
    {
        public GetAllContactsClientQueryValidator()
        {
            RuleFor(c => c.Id).NotEmpty().NotEqual(Guid.Empty);
        }
    }
}
