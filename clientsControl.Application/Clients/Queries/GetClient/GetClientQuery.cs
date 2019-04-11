using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Application.Clients.Queries.GetClient
{
    public class GetClientQuery : IRequest<GetClientClientDto>
    {
        public Guid Id { set; get; }
    }
}
 