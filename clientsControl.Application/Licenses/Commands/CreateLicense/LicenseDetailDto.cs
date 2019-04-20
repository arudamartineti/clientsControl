using AutoMapper;
using clientsControl.Application.Interfaces.Mapping;
using clientsControl.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Application.Licenses.Commands.CreateLicense
{
    public class LicenseDetailDto : IHaveCustomMapping
    {
        public Guid ModuleId { set; get; }
        public Guid? LicenceId { set; get; }
        public int Licencias { set; get; }
        public int PcAdicionales { set; get; }
        public int PcConsultas { set; get; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<LicenseDetailDto, LicenseDetail>();
            configuration.CreateMap<LicenseDetail, LicenseDetailDto>();
        }
    }
}
