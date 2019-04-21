using AutoMapper;
using clientsControl.Application.Licenses.Queries.GetAllLicenseSelect;
using clientsControl.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace clientsControl.Application.Licenses.Queries.GetAllLicenseClientSelect
{
    public class GetAllLicenseClientSelectQueryHandler : IRequestHandler<GetAllLicenseClientSelectQuery, IEnumerable<GetAllLicenseSelectDto>>
    {
        private clientsControlDbContext db;
        private IMapper mapper;

        public GetAllLicenseClientSelectQueryHandler(clientsControlDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<GetAllLicenseSelectDto>> Handle(GetAllLicenseClientSelectQuery request, CancellationToken cancellationToken)
        {
            var qry =
               from l in db.Licenses
               where l.Descontinued == false && l.ClientId == request.Id
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
