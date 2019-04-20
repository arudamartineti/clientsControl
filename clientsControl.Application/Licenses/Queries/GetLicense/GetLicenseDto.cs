using AutoMapper;
using clientsControl.Application.Interfaces.Mapping;
using clientsControl.Application.Licenses.Commands.CreateLicense;
using clientsControl.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Application.Licenses.Queries.GetLicense
{
    public class GetLicenseDto : IHaveCustomMapping
    {
        public Guid Id { set; get; }
        public string REUP { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public DateTime CreationDate { get; set; }
        //public bool Descontinued { get; set; }
        public Guid ClientId { get; set; }
        public string ClientDescription { get; set; }
        public string ClientCode { get; set; }
        public Guid VersionId { get; set; }
        public string VersionDescription { get; set; }
        public Guid StockTypeId { get; set; }
        public string StockTypeDescription { get; set; }
        public Guid ClasificationId { get; set; }
        public string ClasificationClientDescription { get; set; }
        public List<LicenseDetailDto> LicenseDetails { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<License, GetLicenseDto>();
        }
    }
}
