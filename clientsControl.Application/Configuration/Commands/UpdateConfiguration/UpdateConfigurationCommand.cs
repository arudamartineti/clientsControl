using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Application.Configuration.Commands.UpdateConfiguration
{
    public class UpdateConfigurationCommand : IRequest<UpdateConfigurationDto>
    {        
        public int ClientConsecutive { get; set; }

        public int LicenceConsecutive { get; set; }

        public string SmtpServer { get; set; }

        public string SmtpPort { get; set; }

        public string StmpUser { get; set; }

        public string SmtpPassword { get; set; }

        public string GeneratedPaymentControlPath { get; set; }
    }
}
