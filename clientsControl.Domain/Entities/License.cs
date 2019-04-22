using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Domain.Entities
{
    public class License
    {
        public License()
        {
            LicenseDetails = new HashSet<LicenseDetail>();
            LicenseNames = new HashSet<LicenseName>();
            PaymentsControl = new HashSet<PaymentControl>();
        }

        public Guid Id { set; get; }
        public string REUP { get; set; }        
        public string Name { get; set; }        
        public string Code { get; set; }
        public DateTime CreationDate { get; set; }        
        public bool Descontinued { get; set; }
        public Guid ClientId { get; set; }        
        public Client Client { get; set; }        
        public AssetsVersion Version { get; set; }
        public Guid VersionId { get; set; }        
        public StockType StockType { get; set; }
        public Guid StockTypeId { get; set; }
        public virtual ICollection<LicenseDetail> LicenseDetails { get; set; }
        public virtual ICollection<LicenseName> LicenseNames { set; get; }
        public virtual ICollection<PaymentControl> PaymentsControl { get; set; }
        public LicenseClientClasification Clasification { get; set; }
        public virtual ICollection<Contact> Contacts { set; get; }
        public Guid ClasificationId { get; set; }
    }
}
