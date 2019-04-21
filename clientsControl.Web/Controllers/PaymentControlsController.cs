using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using clientsControl.Application.PaymentControls.Commands.CreatePaymentControl;
using clientsControl.Application.PaymentControls.Queries.GetAllPaymentControls;
using Microsoft.AspNetCore.Mvc;

namespace clientsControl.Web.Controllers
{
    public class PaymentControlsController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentControlDto>>> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllPaymentControlsQuery()));
        }

        [HttpPost]
        public async Task<ActionResult<CreatePaymentControlCreated>> Create(CreatePaymentControlCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
