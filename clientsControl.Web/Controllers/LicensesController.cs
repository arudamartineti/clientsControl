using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using clientsControl.Application.Licenses.Commands.CreateLicense;
using clientsControl.Application.Licenses.Commands.DeleteLicense;
using clientsControl.Application.Licenses.Commands.UpdateLicense;
using clientsControl.Application.Licenses.Queries.GetAllLicenseClientSelect;
using clientsControl.Application.Licenses.Queries.GetAllLicenses;
using clientsControl.Application.Licenses.Queries.GetAllLicenseSelect;
using clientsControl.Application.Licenses.Queries.GetLicense;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace clientsControl.Web.Controllers
{
    public class LicensesController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LicenseDto>>> Get()
        {
            return Ok(await Mediator.Send(new GetAllLicensesQuery()));
        }

        [HttpGet("select")]
        public async Task<ActionResult<IEnumerable<GetAllLicenseSelectDto>>> GetSelect()
        {
            return Ok(await Mediator.Send(new GetAllLicenseSelectQuery()));
        }

        [HttpGet("client/{id}/select")]
        public async Task<ActionResult<IEnumerable<GetAllLicenseSelectDto>>> GetLicenseClientSelect(Guid Id)
        {
            return Ok(await Mediator.Send(new GetAllLicenseClientSelectQuery() { Id = Id }));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LicenseDto>> GetLicense(Guid id)
        {
            return Ok(await Mediator.Send(new GetLicenseQuery() { Id = id }));
        }

        [HttpPost]
        public async Task<ActionResult<CreateLicenseCreated>> Post(CreateLicenseCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut]
        public async Task<ActionResult<UpdateLicenseUpdated>> Put(UpdateLicenseCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> Delete(DeleteLicenseCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

    }
}
