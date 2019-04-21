using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Application.PaymentControls.Queries.GetAllPaymentControls
{
    public class GetAllPaymentControlsQuery : IRequest<IEnumerable<PaymentControlDto>>
    {
    }
}
