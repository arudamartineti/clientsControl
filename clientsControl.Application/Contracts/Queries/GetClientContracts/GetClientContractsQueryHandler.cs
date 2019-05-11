using clientsControl.Application.Contracts.Queries.GetAllContracts;
using clientsControl.Domain.Entities;
using clientsControl.Persistence;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace clientsControl.Application.Contracts.Queries.GetClientContracts
{
    public class GetClientContractsQueryHandler : IRequestHandler<GetClientContractsQuery, IEnumerable<ContractDto>>
    {

        private clientsControlDbContext db;
        private UserManager<ApplicationUser> userManager;

        public GetClientContractsQueryHandler(clientsControlDbContext db, UserManager<ApplicationUser> userManager)
        {
            this.db = db;
            this.userManager = userManager;
        }

        public async Task<IEnumerable<ContractDto>> Handle(GetClientContractsQuery request, CancellationToken cancellationToken)
        {
            var qry =
                from contract in db.Contracts
                join client in db.Clients on contract.ClientId equals client.Id into clients
                from client in clients.DefaultIfEmpty()
                join user in userManager.Users on contract.IdInstalador equals user.Id into users
                from user in users.DefaultIfEmpty()
                where contract.Discontinued == false && contract.ClientId == request.Id
                select new ContractDto()
                {
                    Id = contract.Id,
                    Client = client.Description,
                    ClientId = contract.ClientId,
                    Numero = contract.Numero,
                    Suplemento = contract.Suplemento,
                    NumeroSuplement = contract.NumeroSuplement,
                    FechaEntrega = contract.FechaEntrega,
                    FechaFirma = contract.FechaFirma,
                    FechaRecibido = contract.FechaRecibido,
                    IdInstalador = contract.IdInstalador,
                    Instalador = user.FullName,
                    Discontinued = contract.Discontinued,
                    Objeto = contract.Objeto,
                    Ubicacion = contract.Ubicacion,
                    Master = contract.Master,
                    InicioPostVenta = contract.InicioPostVenta,
                    FinalPostVenta = contract.FinalPostVenta,
                    ImporteLicenciasCUC = contract.ImporteLicenciasCUC,
                    ImporteLicenciasMN = contract.ImporteLicenciasMN,
                    ImportePostVentaCUC = contract.ImportePostVentaCUC,
                    ImportePostVentaMN = contract.ImportePostVentaMN
                };

            return qry;
        }
    }
}
