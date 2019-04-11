using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Application.Licenses.Queries.GetAllLicenses
{
    public class GetAllLicensesQuery : IRequest<IEnumerable<LicenseDto>>
    {
    }
}
