using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Application.Modules.Commands.UpdateModule
{
    public class UpdateModuleUpdated
    {
        public Guid Id { set; get; }
        public string Description { get; set; }
        public int WorkStations { get; set; }
    }
}
