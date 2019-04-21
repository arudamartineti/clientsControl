using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using clientsControl.Application.Clients.Commands.CreateClient;
using clientsControl.Application.Clients.Commands.DeleteClient;
using clientsControl.Application.Clients.Commands.UpdateClient;
using clientsControl.Application.Clients.Queries.GetAllClients;
using clientsControl.Application.Clients.Queries.GetAllClientsSelect;
using clientsControl.Application.Clients.Queries.GetClient;
using clientsControl.Application.LicenseClientsClasifications.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace clientsControl.Web.Controllers
{

    public class ClientsController : BaseController
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ClientDto>>> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllClientsQuery()));
        }

        [HttpGet("select")]
        public async Task<ActionResult<IEnumerable<GetAllClientsSelectDto>>> GetSelect()
        {
            return Ok(await Mediator.Send(new GetAllClientsSelectQuery()));
        }

        [HttpGet("clasifications/{id}")]
        public async Task<ActionResult<IEnumerable<LicenseClientClasificationDto>>> GetAllClasifications(Guid id)
        {
            return Ok(await Mediator.Send(new GetLicenseClasificationsClientQuery() { Id = id } ));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetClientClientDto>> Get(Guid Id)
        {
            return Ok(await Mediator.Send(new GetClientQuery() { Id = Id }));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UpdateClientUpdated>> Update(Guid Id, [FromBody]UpdateClientCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost]        
        public async Task<ActionResult<CreateClientCreated>> Create([FromBody]CreateClientCommand command)
        {            
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            return Ok(await Mediator.Send(new DeleteClientCommand() { Id = id }));    
        }
    }
}
