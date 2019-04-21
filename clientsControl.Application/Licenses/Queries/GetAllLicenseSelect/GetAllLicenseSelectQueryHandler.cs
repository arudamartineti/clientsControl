using AutoMapper;
using clientsControl.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace clientsControl.Application.Licenses.Queries.GetAllLicenseSelect
{
    public class GetAllLicenseSelectQueryHandler : IRequestHandler<GetAllLicenseSelectQuery, IEnumerable<GetAllLicenseSelectDto>>
    {
        private IMapper mapper;
        private clientsControlDbContext db;

        public GetAllLicenseSelectQueryHandler(IMapper mapper, clientsControlDbContext db)
        {
            this.mapper = mapper;
            this.db = db;
        }

        public async Task<IEnumerable<GetAllLicenseSelectDto>> Handle(GetAllLicenseSelectQuery request, CancellationToken cancellationToken)
        {
            var qry =
                from l in db.Licenses
                where l.Descontinued == false
                select new GetAllLicenseSelectDto()
                {
                    Id = l.Id,
                    Code = l.Code,
                    Name = l.Name
                };

            return qry;
        }
    }
}
