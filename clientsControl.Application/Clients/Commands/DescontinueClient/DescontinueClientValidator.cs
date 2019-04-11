using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Application.Clients.Commands.DescontinueClient
{
    public class DescontinueClientValidator : AbstractValidator<DescontinueClientCommand>
    {
        public DescontinueClientValidator()
        {
            RuleFor(c => c.Id).NotEmpty().NotEqual(Guid.Empty);
        }
    }
}
