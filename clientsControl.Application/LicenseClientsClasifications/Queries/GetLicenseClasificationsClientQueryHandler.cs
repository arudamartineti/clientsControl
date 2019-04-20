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

namespace clientsControl.Application.LicenseClientsClasifications.Queries
{
    public class GetLicenseClasificationsClientQueryHandler : IRequestHandler<GetLicenseClasificationsClientQuery, IEnumerable<LicenseClientClasificationDto>>
    {
        private clientsControlDbContext db;
        private IMapper mapper;

        public GetLicenseClasificationsClientQueryHandler(clientsControlDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<LicenseClientClasificationDto>> Handle(GetLicenseClasificationsClientQuery request, CancellationToken cancellationToken)
        {
            var ent = await db.Clients.FindAsync(request.Id);

            if (ent == null)
            {
                throw new NotFoundException(nameof(Client), request.Id);
            }

            return mapper.ProjectTo<LicenseClientClasificationDto>(db.LicenseClientClasification.Where(c => c.ClientId == request.Id));
          
        }
    }
}
