using clientsControl.Application.Modules.Queries.GetAllModules;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Application.Modules.Queries.GetModule
{
    public class GetModuleQuery : IRequest<ModuleDto>
    {
        public Guid Id { set; get; }
    }
}
