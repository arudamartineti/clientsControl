using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Application.LicenseClientsClasifications.Queries
{
    public class GetLicenseClasificationsClientQuery : IRequest<IEnumerable<LicenseClientClasificationDto>>
    {
       public Guid Id { set; get; }
    }
}
