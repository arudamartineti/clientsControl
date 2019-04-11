using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using clientsControl.Application.Contacts.Commands.CreateContact;
using clientsControl.Application.Contacts.Commands.DeleteContact;
using clientsControl.Application.Contacts.Commands.UpdateContact;
using clientsControl.Application.Contacts.Queries.GetAllContacts;
using clientsControl.Application.Contacts.Queries.GetAllContactsClient;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace clientsControl.Web.Controllers
{
    public class ContactsController : BaseController
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ContactAllDto>>> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllContactsQuery()));
        }

        [HttpGet("client/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ContactsAllClientDto>>> GetAllContactsClient(Guid Id)
        {
            return Ok(await Mediator.Send(new GetAllContactsClientQuery() { Id = Id }));
        }

        [HttpPost]
        public async Task<ActionResult<CreateContactCreated>> Create([FromBody]CreateContactCommand createContact)
        {
            return Ok(await Mediator.Send(createContact));
        }


        [HttpPut]
        public async Task<ActionResult<UpdateContactUpdated>> Update([FromBody]UpdateContactCommand updateContact)
        {
            return Ok(await Mediator.Send(updateContact));
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(Guid Id)
        {
            return Ok(await Mediator.Send(new DeleteContactCommand() { Id = Id }));
        }


    }
}
