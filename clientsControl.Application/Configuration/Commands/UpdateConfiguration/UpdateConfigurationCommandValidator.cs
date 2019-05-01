using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Application.Configuration.Commands.UpdateConfiguration
{
    public class UpdateConfigurationCommandValidator : AbstractValidator<UpdateConfigurationCommand>
    {
        public UpdateConfigurationCommandValidator()
        {            
            RuleFor(c => c.GeneratedPaymentControlPath).NotEmpty();
            RuleFor(c => c.SmtpServer).NotEmpty();            
        }
    }
}
