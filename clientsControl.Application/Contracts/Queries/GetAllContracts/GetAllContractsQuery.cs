using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Application.Contracts.Queries.GetAllContracts
{
    public class GetAllContractsQuery : IRequest<IEnumerable<ContractDto>>
    {
    }
}
