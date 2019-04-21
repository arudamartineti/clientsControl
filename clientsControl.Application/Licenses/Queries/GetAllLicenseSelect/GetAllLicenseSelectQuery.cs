using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Application.Licenses.Queries.GetAllLicenseSelect
{
    public class GetAllLicenseSelectQuery : IRequest<IEnumerable<GetAllLicenseSelectDto>>
    {
    }
}
