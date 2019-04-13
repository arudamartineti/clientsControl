using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using clientsControl.Application.Modules.Commands.CreateModule;
using clientsControl.Application.Modules.Commands.DeleteModule;
using clientsControl.Application.Modules.Commands.UpdateModule;
using clientsControl.Application.Modules.Queries.GetAllModules;
using clientsControl.Application.Modules.Queries.GetModule;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace clientsControl.Web.Controllers
{
    public class ModulesController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ModuleDto>>> Get()
        {
            return Ok(await Mediator.Send(new GetAllModulesQuery()));
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ModuleDto>> Get(Guid id)
        {
            return Ok(await Mediator.Send(new GetModuleQuery() { Id = id }));
        }

        [HttpPost]
        public async Task<ActionResult<CreateModuleCreated>> Post([FromBody]CreateModuleCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ModuleDto>> Put(Guid id, [FromBody]UpdateModuleCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ModuleDto>> Delete(Guid id)
        {
            return Ok(await Mediator.Send(new DeleteModuleCommand() { Id = id }));
        }


    }
}
