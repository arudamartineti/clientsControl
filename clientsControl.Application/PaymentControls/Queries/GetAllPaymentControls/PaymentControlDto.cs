using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Application.PaymentControls.Queries.GetAllPaymentControls
{
    public class PaymentControlDto
    {
        public Guid Id { set; get; }
        public DateTime GeneratedDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public Guid LicenceId { get; set; }
        public string LicenseName { get; set; }
        public string ClientDescription { get; set; }
        public bool SentByEmail { get; set; }
        public DateTime SentByEmailDate { set; get; }
    }
}
