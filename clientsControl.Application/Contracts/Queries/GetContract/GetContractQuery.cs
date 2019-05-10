using clientsControl.Application.Contracts.Queries.GetAllContracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Application.Contracts.Queries.GetContract
{
    public class GetContractQuery : IRequest<ContractDto>
    {
        public Guid Id { set; get; }
    }
}
