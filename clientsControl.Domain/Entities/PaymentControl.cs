using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Domain.Entities
{
    public class PaymentControl
    {
        public Guid Id { set; get; }
        public DateTime GeneratedDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public Guid LicenceId { get; set; }        
        public License License { get; set; }
        public string Localization { get; set; }
        public bool SendByEmail { get; set; }
        public bool Public { set; get; }
        public bool SentByEmail { get; set; }
        public DateTime SentByEmailDate { set; get; }
    }
}
