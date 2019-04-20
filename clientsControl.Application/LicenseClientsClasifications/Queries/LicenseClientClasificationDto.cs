using AutoMapper;
using clientsControl.Application.Interfaces.Mapping;
using clientsControl.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Application.LicenseClientsClasifications.Queries
{
    public class LicenseClientClasificationDto : IHaveCustomMapping
    {
        public Guid Id { set; get; }
        public string Code { get; set; }
        public string Name { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<LicenseClientClasification, LicenseClientClasificationDto>();
        }
    }
}
