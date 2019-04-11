using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Application.Clients.Commands.UpdateClient
{
    public class UpdateClientUpdated : INotification
    {
        public Guid Id { set; get; }
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
