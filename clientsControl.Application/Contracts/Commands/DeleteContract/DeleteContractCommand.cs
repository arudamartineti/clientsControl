using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Application.Contracts.Commands.DeleteContract
{
    public class DeleteContractCommand : IRequest
    {
        public Guid Id { set; get; }
    }
}
