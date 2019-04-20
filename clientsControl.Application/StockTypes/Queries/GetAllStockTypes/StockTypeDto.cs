using AutoMapper;
using clientsControl.Application.Interfaces.Mapping;
using clientsControl.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Application.StockTypes.Queries.GetAllStockTypes
{
    public class StockTypeDto : IHaveCustomMapping
    {
        public Guid Id { set; get; }
        public string Description { get; set; }
        public int WorkStations { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<StockType, StockTypeDto>();
        }
    }
}
