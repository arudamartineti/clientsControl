using clientsControl.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace clientsControl.Application.Licenses.Queries.GetStaticsLicenses
{
    public class GetStaticsLicensesQueryHandler : IRequestHandler<GetStaticsLicensesQuery, GetStaticsLicensesQueryDto>
    {
        private clientsControlDbContext db;

        public GetStaticsLicensesQueryHandler(clientsControlDbContext db)
        {
            this.db = db;
        }

        public async Task<GetStaticsLicensesQueryDto> Handle(GetStaticsLicensesQuery request, CancellationToken cancellationToken)
        {
            var result = new GetStaticsLicensesQueryDto();

            result.Clients = db.Clients.Count();
            result.ClientsMoreThanOneLicense = db.Clients.Where(c => c.Licenses.Count > 1).Count();
            result.ClientsWithoutLicenses = db.Clients.Where(c => c.Licenses.Count == 0).Count();
            result.Licenses = db.Licenses.Count();
            result.LicensesEmpty = db.Licenses.Where(c => c.LicenseDetails.Where(d => d.Licencias == 0).Count() == c.LicenseDetails.Count()).Count();            

            return result;
        }
    }
}
