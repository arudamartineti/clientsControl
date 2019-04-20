using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Application.PaymentControls.Commands.CreatePaymentControl
{
    public class CreatePaymentControlCommandValidator : AbstractValidator<CreatePaymentControlCommand>
    {
        public CreatePaymentControlCommandValidator()
        {
            RuleFor(c => c.LicenceId).NotEmpty().NotEqual(Guid.Empty);
            RuleFor(c => c.ExpirationDate).NotEmpty();
        }
    }
}
