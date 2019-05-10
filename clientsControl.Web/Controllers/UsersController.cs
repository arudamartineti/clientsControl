using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using clientsControl.Application.Users.Commands.AddRolesUser;
using clientsControl.Application.Users.Commands.AuthorizeUser;
using clientsControl.Application.Users.Queries.GetAllInstallers;
using clientsControl.Application.Users.Queries.GetAllRoles;
using clientsControl.Application.Users.Queries.GetAllUsers;
using clientsControl.Application.Users.Queries.GetUser;
using clientsControl.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace clientsControl.Web.Controllers
{
    public class UsersController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetAllUsersQueryDto>>> getUsers()
        {
            return Ok(await Mediator.Send(new GetAllUsersQuery()));
        }

        [HttpGet("instaladores")]
        public async Task<ActionResult<IEnumerable<GetAllUsersQueryDto>>> getInstaladores()
        {
            return Ok(await Mediator.Send(new GetAllInstallersQuery()));
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<GetAllUsersQueryDto>> getUser(string id)
        {
            return Ok(await Mediator.Send(new GetUserQuery() { Id = id }));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<bool>> authorizeUser(string id)
        {
            return Ok(await Mediator.Send(new AuthorizeUserCommand() { Id = id }));
        }


        [HttpGet("roles")]
        public async Task<ActionResult<IEnumerable<GetAllUsersQueryDto>>> getRoles()
        {
            return Ok(await Mediator.Send(new GetAllRolesQuery()));
        }

        [HttpPost("{id}/roles")]
        public async Task<ActionResult<GetAllUsersQueryDto>> addRolesToUser(string Id, [FromBody]AddRolesUserCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

    }
}
