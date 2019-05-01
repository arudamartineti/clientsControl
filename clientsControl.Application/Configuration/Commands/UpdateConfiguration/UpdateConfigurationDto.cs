using AutoMapper;
using clientsControl.Application.Interfaces.Mapping;
using System;
using System.Collections.Generic;
using System.Text;
using clientsControl.Domain.Entities;

namespace clientsControl.Application.Configuration.Commands.UpdateConfiguration
{
    public class UpdateConfigurationDto : IHaveCustomMapping
    {
        public Guid Id { set; get; }
        public int ClientConsecutive { get; set; }

        public int LicenceConsecutive { get; set; }

        public string SmtpServer { get; set; }

        public string SmtpPort { get; set; }

        public string StmpUser { get; set; }

        public string SmtpPassword { get; set; }

        public string GeneratedPaymentControlPath { get; set; }
        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<clientsControl.Domain.Entities.Configuration, UpdateConfigurationDto>();
            configuration.CreateMap<UpdateConfigurationDto, clientsControl.Domain.Entities.Configuration>();
        }
    }
}
