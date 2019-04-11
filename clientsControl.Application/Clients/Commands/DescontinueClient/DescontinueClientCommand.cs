using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Application.Clients.Commands.DescontinueClient
{
    public class DescontinueClientCommand : IRequest
    {
        public Guid Id { set; get; }
    }
}
