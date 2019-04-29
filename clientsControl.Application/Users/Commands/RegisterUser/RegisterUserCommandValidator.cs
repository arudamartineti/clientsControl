using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Application.Users.Commands.RegisterUser
{
    public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator()
        {
            RuleFor(c => c.FullName).MaximumLength(255).NotEmpty();
            RuleFor(c => c.Email).EmailAddress();
            RuleFor(c => c.PhoneNumber).NotEmpty();
            RuleFor(c => c.Password).NotEmpty();
        }
    }
}
