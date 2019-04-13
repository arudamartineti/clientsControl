using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Application.Clients.Commands.UpdateClient
{
    public class UpdateClientCommandValidator : AbstractValidator<UpdateClientCommand>
    {
        public UpdateClientCommandValidator()
        {
            RuleFor(c => c.Id).NotEmpty();
            RuleFor(c => c.Id).NotEqual(Guid.Empty);

            RuleFor(c => c.Code).NotEmpty();
            RuleFor(c => c.Description).NotEmpty();
        }
    }
}
