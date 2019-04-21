using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Application.Clients.Queries.GetAllClientsSelect
{
    public class GetAllClientsSelectQuery : IRequest<IEnumerable<GetAllClientsSelectDto>>
    {
    }
}
