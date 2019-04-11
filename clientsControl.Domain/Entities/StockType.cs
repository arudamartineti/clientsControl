using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Domain.Entities
{
    public class StockType
    {

        public StockType()
        {
            Licenses = new HashSet<License>();
        }

        public Guid Id { set; get; }
        public string Description { get; set; }
        public int WorkStations { get; set; }
        public ICollection<License> Licenses { get; private set; }
    }
}
