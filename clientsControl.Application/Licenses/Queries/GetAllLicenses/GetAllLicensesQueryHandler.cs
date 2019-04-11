using AutoMapper;
using clientsControl.Domain.Entities;
using clientsControl.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace clientsControl.Application.Licenses.Queries.GetAllLicenses
{
    public class GetAllLicensesQueryHandler : IRequestHandler<GetAllLicensesQuery, IEnumerable<LicenseDto>>
    {
        private clientsControlDbContext db;
        private IMapper mapper;

        public GetAllLicensesQueryHandler(clientsControlDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<LicenseDto>> Handle(GetAllLicensesQuery request, CancellationToken cancellationToken)
        {
            return mapper.ProjectTo<LicenseDto>(db.Licenses.Where(c => c.Descontinued == false).AsQueryable<License>());
        }
    }
}
