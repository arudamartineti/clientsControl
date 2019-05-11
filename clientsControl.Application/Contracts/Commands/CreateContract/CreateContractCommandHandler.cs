using AutoMapper;
using clientsControl.Application.Contracts.Queries.GetAllContracts;
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

namespace clientsControl.Application.Contracts.Commands.CreateContract
{
    public class CreateContractCommandHandler : IRequestHandler<CreateContractCommand, ContractDto>
    {

        private clientsControlDbContext db;
        private IMapper mapper;

        public CreateContractCommandHandler(clientsControlDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<ContractDto> Handle(CreateContractCommand request, CancellationToken cancellationToken)
        {            
            if (db.Contracts.Where(c => c.Numero == request.Numero).Any())
                throw new CodeUsedException(nameof(Contract), request.Numero);

            var contrato = new Contract()
                {
                    Id = Guid.NewGuid(),
                    ClientId = request.ClientId,                    
                    Discontinued = false,
                    FechaEntrega = request.FechaEntrega,
                    FechaFirma = request.FechaFirma,
                    FechaRecibido = request.FechaRecibido,
                    IdInstalador = request.IdInstalador,
                    ImporteLicenciasCUC = request.ImporteLicenciasCUC,
                    ImporteLicenciasMN = request.ImporteLicenciasMN,
                    ImportePostVentaCUC = request.ImportePostVentaCUC,
                    ImportePostVentaMN = request.ImportePostVentaMN,
                    Master = request.Master,
                    InicioPostVenta = request.InicioPostVenta,
                    FinalPostVenta = request.FinalPostVenta,
                    Numero = request.Numero,
                    NumeroSuplement = request.NumeroSuplement,
                    Objeto = request.Objeto,
                    Suplemento = request.Suplemento,
                    Ubicacion = request.Ubicacion
                };

            await db.Contracts.AddAsync(contrato, cancellationToken);

            return mapper.Map<ContractDto>(contrato);
        }
    }
}
