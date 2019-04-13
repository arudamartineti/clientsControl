using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Application.Modules.Commands.DeleteModule
{
    public class DeleteModuleCommand : IRequest
    {
        public Guid Id { set; get; }
    }
}
