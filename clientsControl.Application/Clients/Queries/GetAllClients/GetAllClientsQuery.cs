using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Application.Clients.Queries.GetAllClients
{
    public class GetAllClientsQuery : IRequest<IEnumerable<ClientDto>>
    {
        //public int Page { set; get; }
    }
}
