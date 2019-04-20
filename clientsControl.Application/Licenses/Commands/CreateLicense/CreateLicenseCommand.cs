using clientsControl.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Application.Licenses.Commands.CreateLicense
{
    public class CreateLicenseCommand : IRequest<CreateLicenseCreated>
    {
        public string REUP { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public DateTime CreationDate { get; set; }        
        public Guid ClientId { get; set; }                
        public Guid VersionId { get; set; }        
        public Guid StockTypeId { get; set; }
        public List<LicenseDetailDto> LicenseDetails { get; set; }
    }
}
