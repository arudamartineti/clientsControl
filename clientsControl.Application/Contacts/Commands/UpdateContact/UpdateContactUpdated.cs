using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Application.Contacts.Commands.UpdateContact
{
    public class UpdateContactUpdated
    {
        public Guid Id { set; get; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
