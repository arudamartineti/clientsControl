using AutoMapper;
using clientsControl.Application.Exceptions;
using clientsControl.Domain.Entities;
using clientsControl.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace clientsControl.Application.Clients.Queries.GetClient
{
    public class GetClientQueryHandler : IRequestHandler<GetClientQuery, GetClientClientDto>
    {
        private clientsControlDbContext db;
        IMapper mapper;

        public GetClientQueryHandler(clientsControlDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<GetClientClientDto> Handle(GetClientQuery request, CancellationToken cancellationToken)
        {
            var ent = await db.Clients.FindAsync(request.Id);

            if (ent == null) {
                throw new NotFoundException(nameof(Client), request.Id);
            }

            if (ent.Discontinued) {
                throw new NotFoundException(nameof(Client), request.Id);
            }

            return mapper.Map<GetClientClientDto>(ent);
        }
    }
}
