using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Domain.Entities
{
    public class Module
    {

        public Module()
        {
            LicenseDetails = new HashSet<LicenseDetail>();
        }
        public Guid Id { set; get; }
        public string Description { get; set; }
        public int WorkStations { get; set; }

        public ICollection<LicenseDetail> LicenseDetails { get; private set; }
    }
}
