using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Domain.Entities
{
    public class LicenseClientClasification
    {
        public LicenseClientClasification()
        {
            Licenses = new HashSet<License>();
        }

        public Guid Id { set; get; }
        public string Code { get; set; }
        public string Name { get; set; }        
        public Client Client { set; get; }
        public Guid ClientId { set; get; }
        public ICollection<License> Licenses { get; private set; }
    }
}
