using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Domain.Entities
{
    public class LicenseName
    {
        public Guid Id { set; get; }
        public Guid LicenseId { set; get; }        
        public License License { set; get; }
        public string Name { set; get; }        
        public string REUP { set; get; }
        public DateTime Date { set; get; }        
    }
}
