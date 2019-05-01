using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using clientsControl.Application.Configuration.Commands.UpdateConfiguration;
using clientsControl.Application.Configuration.Queries.GetConfiguration;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace clientsControl.Web.Controllers
{
    public class ConfigurationController : BaseController
    {

        [HttpGet]
        public async Task<ActionResult<UpdateConfigurationDto>> Get()
        {
            return Ok(await Mediator.Send(new GetConfigurationQuery()));
        }

        [HttpPost]
        public async Task<ActionResult<UpdateConfigurationDto>> Set(UpdateConfigurationCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
