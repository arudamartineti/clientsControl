using AutoMapper;
using clientsControl.Application.Interfaces.Mapping;
using clientsControl.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Application.Clients.Queries.GetAllClients
{
    public class ClientDto : IHaveCustomMapping
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string AssetsCode { get; set; }
        public string NombreCorto { get; set; }
        public int Licencias { get; set; }
        public bool PostVenta { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<Client, ClientDto>();
        }
    }
}
