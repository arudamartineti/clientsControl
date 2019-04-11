using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Domain.Entities
{
    public class AssetsVersion
    {
        public AssetsVersion()
        {
            Licenses = new HashSet<License>();
        }
        public Guid Id { set; get; }
        public string Description { get; set; }
        public ICollection<License> Licenses { get; private set; }
    }
}
