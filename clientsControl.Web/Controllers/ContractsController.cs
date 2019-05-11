using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using clientsControl.Application.Contracts.Commands.CreateContract;
using clientsControl.Application.Contracts.Commands.DeleteContract;
using clientsControl.Application.Contracts.Commands.DiscontinueContract;
using clientsControl.Application.Contracts.Commands.UpdateContract;
using clientsControl.Application.Contracts.Queries.GetAllContracts;
using clientsControl.Application.Contracts.Queries.GetClientContracts;
using clientsControl.Application.Contracts.Queries.GetContract;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace clientsControl.Web.Controllers
{
    public class ContractsController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllContractsQuery()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid Id)
        {
            return Ok(await Mediator.Send(new GetContractQuery() { Id = Id }));
        }

        [HttpGet("client/{id}")]
        public async Task<IActionResult> GetClient(Guid Id)
        {
            return Ok(await Mediator.Send(new GetClientContractsQuery() { Id = Id }));
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody]CreateContractCommand command)
        {
                return Ok(await Mediator.Send(command));
        }

        [HttpPost("discontinue/{id}")]
        public async Task<IActionResult> Discontinue(Guid Id)
        {
            return Ok(await Mediator.Send(new DiscontinueContractCommand() { Id = Id }));
        }

        [HttpPut]
        public async Task<IActionResult> Update(Guid Id, [FromBody]UpdateContractCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid Id)
        {
            return Ok(await Mediator.Send(new DeleteContractCommand() { Id = Id }));
        }
    }
}
