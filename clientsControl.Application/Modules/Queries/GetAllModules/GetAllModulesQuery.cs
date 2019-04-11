using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Application.Modules.Queries.GetAllModules
{
    public class GetAllModulesQuery : IRequest<IEnumerable<ModuleDto>>
    {
    }
}
