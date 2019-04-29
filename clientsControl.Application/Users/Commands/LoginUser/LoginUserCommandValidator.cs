using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Application.Users.Commands.LoginUser
{
    public class LoginUserCommandValidator : AbstractValidator<LoginUserCommand>
    {
        public LoginUserCommandValidator()
        {
            RuleFor(c => c.Username).NotEmpty().EmailAddress();
            RuleFor(c => c.Password).NotEmpty();
        }
    }
}
