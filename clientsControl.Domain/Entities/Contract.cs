using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Domain.Entities
{
    public class Contract
    {
        public Guid Id { set; get; }        
        public Client Client { set; get; }
        public Guid ClientId { set; get; }
        public string Numero { set; get; }
        public bool Suplemento { set; get; }
        public int NumeroSuplement { set; get; }
        public DateTime? FechaEntrega { set; get; }
        public DateTime? FechaFirma { set; get; }
        public DateTime? FechaRecibido { set; get; }
        public ApplicationUser Instalador { set; get; }
        public string IdInstalador { set; get; }
        public string Ubicacion { set; get; }
        public string Objeto { set; get; }
        public decimal ImporteLicenciasCUC { set; get; }
        public decimal ImporteLicenciasMN { set; get; }
        public decimal ImportePostVentaCUC { set; get; }
        public decimal ImportePostVentaMN { set; get; }
        public byte? MesInicioPostVenta { set; get; }
        public byte? MesFinalPostVenta { set; get; }
        public byte? AnoFinalPostVenta { set; get; }
        public string Master { set; get; }
        public bool Discontinued { set; get; }

    }
}
