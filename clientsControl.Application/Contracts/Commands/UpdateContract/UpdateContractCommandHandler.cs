using AutoMapper;
using clientsControl.Application.Contracts.Queries.GetAllContracts;
using clientsControl.Application.Exceptions;
using clientsControl.Domain.Entities;
using clientsControl.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace clientsControl.Application.Contracts.Commands.UpdateContract
{
    public class UpdateContractCommandHandler : IRequestHandler<UpdateContractCommand, ContractDto>
    {
        private clientsControlDbContext db;
        private IMapper mapper;

        public UpdateContractCommandHandler(clientsControlDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<ContractDto> Handle(UpdateContractCommand request, CancellationToken cancellationToken)
        {
            var contract = db.Contracts.Find(request.Id);

            if (contract == null)
                throw new NotFoundException(nameof(Contract), request.Id);

            
            contract.Discontinued = false;
            contract.FechaEntrega = request.FechaEntrega;
            contract.FechaFirma = request.FechaFirma;
            contract.FechaRecibido = request.FechaRecibido;
            contract.IdInstalador = request.IdInstalador;
            contract.ImporteLicenciasCUC = request.ImporteLicenciasCUC;
            contract.ImporteLicenciasMN = request.ImporteLicenciasMN;
            contract.ImportePostVentaCUC = request.ImportePostVentaCUC;
            contract.ImportePostVentaMN = request.ImportePostVentaMN;
            contract.Master = request.Master;
            contract.InicioPostVenta = request.InicioPostVenta;
            contract.FinalPostVenta = request.FinalPostVenta;
            contract.Numero = request.Numero;
            contract.NumeroSuplement = request.NumeroSuplement;
            contract.Objeto = request.Objeto;
            contract.Suplemento = request.Suplemento;
            contract.Ubicacion = request.Ubicacion;

            db.Contracts.Update(contract);

            await db.SaveChangesAsync(cancellationToken);

            return mapper.Map<ContractDto>(contract);
        }
    }
}
