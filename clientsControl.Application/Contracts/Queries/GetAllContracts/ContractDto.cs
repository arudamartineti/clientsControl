using AutoMapper;
using clientsControl.Application.Interfaces.Mapping;
using clientsControl.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Application.Contracts.Queries.GetAllContracts
{
    public class ContractDto : IHaveCustomMapping
    {
        public Guid Id { set; get; }
        public string Client { set; get; }
        public Guid ClientId { set; get; }
        public string Numero { set; get; }
        public bool Suplemento { set; get; }
        public int NumeroSuplement { set; get; }
        public DateTime? FechaEntrega { set; get; }
        public DateTime? FechaFirma { set; get; }
        public DateTime? FechaRecibido { set; get; }
        public string Instalador { set; get; }
        public string IdInstalador { set; get; }
        public string Ubicacion { set; get; }
        public string Objeto { set; get; }
        public decimal ImporteLicenciasCUC { set; get; }
        public decimal ImporteLicenciasMN { set; get; }
        public decimal ImportePostVentaCUC { set; get; }
        public decimal ImportePostVentaMN { set; get; }
        public DateTime? InicioPostVenta { set; get; }
        public DateTime? FinalPostVenta { set; get; }
        public string Master { set; get; }
        public bool Discontinued { set; get; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<Contract, ContractDto>();
            configuration.CreateMap<ContractDto, Contract>();
        }
    }
}
