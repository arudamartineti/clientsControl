using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Application.Contacts.Commands.CreateContact
{
    public class CreateContactCommand : IRequest<CreateContactCreated>
    {        
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Guid ClientId { get; set; }
        public bool RecibeLicencias { get; set; }
        public Guid? LicenseId { get; set; }
    }
}
