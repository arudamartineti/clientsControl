using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Domain.Entities
{
    public class LicenseDetail
    {        
        public Guid ModuleId { set; get; }        
        public Guid LicenceId { set; get; }        
        public Module Module { set; get; }        
        public License License { set; get; }
        public int Licencias { set; get; }
        public int PcAdicionales { set; get; }
        public int PcConsultas { set; get; }
    }
}
