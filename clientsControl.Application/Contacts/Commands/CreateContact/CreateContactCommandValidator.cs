using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Application.Contacts.Commands.CreateContact
{
    public class CreateContactCommandValidator : AbstractValidator<CreateContactCommand>
    {
        public CreateContactCommandValidator()
        {
            RuleFor(c => c.ClientId).NotEmpty().NotEqual(Guid.Empty);
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.PhoneNumber).NotEmpty();
        }
    }
}
