using AutoMapper;
using clientsControl.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Application.Clients.Queries.GetClient
{
    public class GetClientClientDto
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<Client, GetClientClientDto>();
        }
    }
}
