using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Application.Licenses.Commands.DiscontinueLincense
{
    public class DiscontinueLincenseCommandValidator : AbstractValidator<DiscontinueLincenseCommand>
    {
        public DiscontinueLincenseCommandValidator()
        {
            RuleFor(c => c.Id).NotEmpty().NotEqual(Guid.Empty);
        }
    }
}
