using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Domain.Entities
{
    public class Configuration
    {
        public Guid Id { set; get; }
        public int ClientConsecutive { get; set; }

        public int LicenceConsecutive { get; set; }

        public string SmtpServer { get; set; }

        public string SmtpPort { get; set; }

        public string StmpUser { get; set; }

        public string SmtpPassword { get; set; }

        public string GeneratedPaymentControlPath { get; set; }
    }
}
