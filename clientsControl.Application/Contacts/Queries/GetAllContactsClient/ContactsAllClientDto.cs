using AutoMapper;
using clientsControl.Application.Interfaces.Mapping;
using clientsControl.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Application.Contacts.Queries.GetAllContactsClient
{
    public class ContactsAllClientDto : IHaveCustomMapping
    {
        public Guid Id { set; get; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<Client, ContactsAllClientDto>();
        }
    }
}
