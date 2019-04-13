using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using clientsControl.Application.AssetsVersions.Commands.CreateAssetsVersion;
using clientsControl.Application.AssetsVersions.Commands.DeleteAssetsVersion;
using clientsControl.Application.AssetsVersions.Commands.UpdateAssetsVersion;
using clientsControl.Application.AssetsVersions.Queries.GetAllAssetsVersions;
using clientsControl.Application.AssetsVersions.Queries.GetAssetsVersion;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace clientsControl.Web.Controllers
{    
    public class AssetsVersionsController : BaseController
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<AssetsVersionDto>>> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllAssetsVersionsQuery()));
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<AssetsVersionDto>> Get(Guid id)
        {
            return Ok(await Mediator.Send(new GetAssetsVersionQuery() { Id = id }));
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<ActionResult<CreateAssetsVersionCreated>> Post([FromBody]CreateAssetsVersionCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<UpdateAssetsVersionUpdated>> Put(Guid id, [FromBody]UpdateAssetsVersionCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            return Ok(await Mediator.Send(new DeleteAssetsVersionCommand() { Id = id }));
        }
    }
}
