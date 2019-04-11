using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Application.Contacts.Queries.GetAllContacts
{
    public class ContactAllDto
    {
        public Guid Id { set; get; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Guid ClientId { set; get; }
        public string ClientCode { set; get; }
        public string ClientDescription { set; get; }
    }
}
