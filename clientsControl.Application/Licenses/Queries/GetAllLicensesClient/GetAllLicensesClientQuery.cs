using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Application.Licenses.Queries.GetAllLicensesClient
{
    public class GetAllLicensesClientQuery : IRequest<IEnumerable<LicenseClientDto>>
    {
        public Guid Id { set; get; }
    }
}
