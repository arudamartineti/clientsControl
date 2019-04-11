using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Application.Licenses.Commands.CreateLicense
{
    public class CreateLicenseCreated
    {
        public Guid Id { set; get;}
        public string REUP { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public DateTime CreationDate { get; set; }
        public bool Descontinued { get; set; }
        public Guid ClientId { get; set; }
        public Guid VersionId { get; set; }
        public Guid StockTypeId { get; set; }
    }
}
