using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Domain.Entities
{
    public class Client
    {

        public Client()
        {
            Contacts = new HashSet<Contact>();
            LicenseClasifications = new HashSet<LicenseClientClasification>();
            Licenses = new HashSet<License>();
            Contracts = new HashSet<Contract>();
        }

        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string AssetsCode { get; set; }
        public bool Discontinued { get; set; }
        public ICollection<Contact> Contacts {get; private set;}
        public ICollection<LicenseClientClasification> LicenseClasifications { get; private set; }
        public ICollection<License> Licenses { get; private set; }
        public ICollection<Contract> Contracts { get; private set; }
    }
}
