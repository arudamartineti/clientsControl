using AutoMapper;
using clientsControl.Application.Interfaces.Mapping;
using clientsControl.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Application.AssetsVersions.Queries.GetAllAssetsVersions
{
    public class AssetsVersionDto : IHaveCustomMapping
    {
        public Guid Id { set; get; }
        public string Description { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<AssetsVersion, AssetsVersionDto>();
        }
    }
}
