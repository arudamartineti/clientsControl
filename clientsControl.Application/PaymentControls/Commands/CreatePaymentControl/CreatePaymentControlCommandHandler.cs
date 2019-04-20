using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace clientsControl.Application.PaymentControls.Commands.CreatePaymentControl
{
    public class CreatePaymentControlCommandHandler : IRequestHandler<CreatePaymentControlCommand, CreatePaymentControlCreated>
    {

        public async Task<CreatePaymentControlCreated> Handle(CreatePaymentControlCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
