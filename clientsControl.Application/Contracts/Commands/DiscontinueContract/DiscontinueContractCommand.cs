using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Application.Contracts.Commands.DiscontinueContract
{
    public class DiscontinueContractCommand : IRequest
    {
        public Guid Id { set; get; }
    }
}
