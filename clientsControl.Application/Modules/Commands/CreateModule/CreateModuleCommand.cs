using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Application.Modules.Commands.CreateModule
{
    public class CreateModuleCommand : IRequest<CreateModuleCreated>
    {
        public string Description { get; set; }
        public int WorkStations { get; set; }
    }
}
