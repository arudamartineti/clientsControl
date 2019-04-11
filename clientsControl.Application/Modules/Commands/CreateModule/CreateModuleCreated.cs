using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Application.Modules.Commands.CreateModule
{
    public class CreateModuleCreated
    {
        public Guid Id { set; get; }
        public string Description { get; set; }
        public int WorkStations { get; set; }
    }
}
