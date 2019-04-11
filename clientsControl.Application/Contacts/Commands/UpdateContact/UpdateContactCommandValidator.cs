using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Application.Contacts.Commands.UpdateContact
{
    public class UpdateContactCommandValidator : AbstractValidator<UpdateContactCommand>
    {
        public UpdateContactCommandValidator()
        {
            RuleFor(c => c.Id).NotEmpty().NotEqual(Guid.Empty);
            RuleFor(c => c.Name).NotEmpty().MaximumLength(50);
            RuleFor(c => c.Email).NotEmpty().MaximumLength(250);
            RuleFor(c => c.PhoneNumber).NotEmpty().MaximumLength(50);

        }
    }
}
