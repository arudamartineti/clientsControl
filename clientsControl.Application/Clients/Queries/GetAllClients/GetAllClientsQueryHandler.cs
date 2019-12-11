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
            var licensesClient =
                from l in db.Licenses
                group l by l.ClientId into g
                select new
                {
                    clientId = g.Key,
                    licensesCount = g.Count()
                };

            var contractsClient =
                from c in db.Contracts
                group c by c.ClientId into g
                select new {
                    clientId = g.Key,
                    contractsCount = g.Count(),
                    postVentaContractsCount = g.Where(c => DateTime.Today >= c.InicioPostVenta  && DateTime.Today <= c.FinalPostVenta).Count()
                };

            var qry =
                from c in db.Clients
                join l in licensesClient on c.Id equals l.clientId into ls
                from l in ls.DefaultIfEmpty()
                join ct in contractsClient on c.Id equals ct.clientId into cts
                from ct in cts.DefaultIfEmpty()
                select new ClientDto()
                {
                    Id = c.Id,
                    Code = c.Code,
                    Description = c.Description,
                    AssetsCode = c.AssetsCode,
                    NombreCorto = c.NombreCorto,
                    Licencias = l.clientId == null ? 0 : l.licensesCount,
                    PostVenta = ct.clientId == null ? false : (ct.postVentaContractsCount > 0)
                };

            return qry;            
        }
        
    }
}
