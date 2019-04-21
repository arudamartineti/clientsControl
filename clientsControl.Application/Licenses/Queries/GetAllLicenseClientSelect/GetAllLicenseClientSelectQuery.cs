using clientsControl.Application.Licenses.Queries.GetAllLicenseSelect;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Application.Licenses.Queries.GetAllLicenseClientSelect
{
    public class GetAllLicenseClientSelectQuery : IRequest<IEnumerable<GetAllLicenseSelectDto>>
    {
        public Guid Id { set; get; }
    }
}
