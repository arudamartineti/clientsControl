using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Application.Clients.Commands.DeleteClient
{
    public class DeleteClientCommand : IRequest
    {
        public Guid Id { set; get; }
    }
}
