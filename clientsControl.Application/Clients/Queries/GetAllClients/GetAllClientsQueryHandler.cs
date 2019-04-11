using AutoMapper;
using AutoMapper.QueryableExtensions;
using clientsControl.Domain.Entities;
using clientsControl.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace clientsControl.Application.Clients.Queries.GetAllClients
{
    public class GetAllClientsQueryHandler : IRequestHandler<GetAllClientsQuery, IEnumerable<ClientDto>>
    {
        private clientsControlDbContext db;
        private IMapper mapper;
        public GetAllClientsQueryHandler(clientsControlDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<ClientDto>> Handle(GetAllClientsQuery request, CancellationToken cancellationToken)
        {
            return mapper.ProjectTo<ClientDto>(db.Clients.Where(c => !c.Discontinued).AsQueryable<Client>());
        }
        
    }
}
