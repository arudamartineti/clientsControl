using AutoMapper;
using clientsControl.Application.Interfaces.Mapping;
using clientsControl.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Application.PaymentControls.Commands.CreatePaymentControl
{
    public class CreatePaymentControlCreated : IHaveCustomMapping
    {
        public Guid Id { get; set; }
        public DateTime GeneratedDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public Guid LicenceId { get; set; }
        public bool SendByEmail { get; set; }
        public bool Public { set; get; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<PaymentControl, CreatePaymentControlCreated>();
        }
    }
}
