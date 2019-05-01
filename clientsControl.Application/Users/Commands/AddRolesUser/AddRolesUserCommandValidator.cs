using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Application.Users.Commands.AddRolesUser
{
    public class AddRolesUserCommandValidator : AbstractValidator<AddRolesUserCommand>
    {
        public AddRolesUserCommandValidator()
        {
            RuleFor(c => c.Id).NotEmpty();
        }
    }
}
