using clientsControl.Application.Contracts.Queries.GetAllContracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Application.Contracts.Queries.GetClientContracts
{
    public class GetClientContractsQuery : IRequest<IEnumerable<ContractDto>>
    {
        public Guid Id { set; get; }
    }
}
