using AutoMapper;
using clientsControl.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace clientsControl.Application.Clients.Queries.GetAllClientsSelect
{
    public class GetAllClientsSelectQueryHandler : IRequestHandler<GetAllClientsSelectQuery, IEnumerable<GetAllClientsSelectDto>>
    {
        private clientsControlDbContext db;
        private IMapper mapper;

        public GetAllClientsSelectQueryHandler(clientsControlDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<GetAllClientsSelectDto>> Handle(GetAllClientsSelectQuery request, CancellationToken cancellationToken)
        {
            var qry =
                from c in db.Clients
                where c.Discontinued == false
                select new GetAllClientsSelectDto()
                {
                    Id = c.Id,
                    Code = c.Code,
                    Description = c.Description,
                    NombreCorto = c.NombreCorto
                };

            return qry;
        }
    }
}
