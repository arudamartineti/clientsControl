using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Application.PaymentControls.Commands.CreatePaymentControl
{
    public class CreatePaymentControlCommand
    {
        public DateTime GeneratedDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public Guid LicenceId { get; set; }
        public bool SendByEmail { get; set; }
        public bool Public { set; get; }
    }
}
