using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Application.Users.Commands.AuthorizeUser
{
    public class AuthorizeUserCommandValidator : AbstractValidator<AuthorizeUserCommand>
    {
        public AuthorizeUserCommandValidator()
        {
            RuleFor(c => c.Id).NotEmpty();
        }
    }
}
