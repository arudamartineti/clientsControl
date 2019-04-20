using clientsControl.Application.Licenses.Queries.GetAllLicenses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Application.Licenses.Queries.GetLicense
{
    public class GetLicenseQuery : IRequest<GetLicenseDto>
    {
        public Guid Id { set; get; }
    }
}
