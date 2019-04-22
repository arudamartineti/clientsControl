using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Domain.Entities
{
    public class Contact
    {
        public Guid Id { set; get; }
        public string Name { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }
        public bool RecibeLicencias { get; set; }

        public Guid ClientId { get; set; }        
        public Client Client { get; set; }
        public Guid? LicenseId { get; set; }
        public License License { get; set; }
    }
}
