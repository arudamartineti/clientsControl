using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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


        [HttpGet("{id}")]
        public async Task<ActionResult<GetAllUsersQueryDto>> getUser(string id)
        {
            return Ok(await Mediator.Send(new GetUserQuery() { Id = id}));
        }
    }
}
