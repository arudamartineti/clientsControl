using clientsControl.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using clientsControl.Domain.Entities;

namespace clientsControl.Application.Contracts.Queries.GetAllContracts
{
    public class GetAllContractsQueryHandler : IRequestHandler<GetAllContractsQuery, IEnumerable<ContractDto>>
    {
        private clientsControlDbContext db;
        private UserManager<ApplicationUser> userManager;

        public GetAllContractsQueryHandler(clientsControlDbContext db, UserManager<ApplicationUser> userManager)
        {
            this.db = db;
            this.userManager = userManager;
        }

        public async Task<IEnumerable<ContractDto>> Handle(GetAllContractsQuery request, CancellationToken cancellationToken)
        {
            var qry =
                from contract in db.Contracts
                join client in db.Clients on contract.ClientId equals client.Id into clients
                from client in clients.DefaultIfEmpty()   
                join user in userManager.Users on contract.IdInstalador equals user.Id into users
                from user in users.DefaultIfEmpty()
                where contract.Discontinued == false
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
