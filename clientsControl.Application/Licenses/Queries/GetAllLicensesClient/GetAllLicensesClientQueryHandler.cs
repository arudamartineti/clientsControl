using AutoMapper;
using clientsControl.Application.Exceptions;
using clientsControl.Domain.Entities;
using clientsControl.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace clientsControl.Application.Licenses.Queries.GetAllLicensesClient
{
    public class GetAllLicensesClientQueryHandler : IRequestHandler<GetAllLicensesClientQuery, IEnumerable<LicenseClientDto>>
    {
        private clientsControlDbContext db;
        private IMapper mapper;

        public GetAllLicensesClientQueryHandler(clientsControlDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<LicenseClientDto>> Handle(GetAllLicensesClientQuery request, CancellationToken cancellationToken)
        {
            if (!db.Clients.Where(c => c.Id == request.Id).Any())
                throw new NotFoundException(nameof(Client), request.Id);

            return mapper.ProjectTo<LicenseClientDto>(db.Licenses.Where(c => c.ClientId == request.Id).AsQueryable<License>());
        }
    }
}
