using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using clientsControl.Application.StockTypes.Commands.CreateStockType;
using clientsControl.Application.StockTypes.Commands.DeleteStockType;
using clientsControl.Application.StockTypes.Commands.UpdateStockType;
using clientsControl.Application.StockTypes.Queries.GetAllStockTypes;
using clientsControl.Application.StockTypes.Queries.GetStockType;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace clientsControl.Web.Controllers
{
    public class StockTypesController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StockTypeDto>>> Get()
        {
            return Ok(await Mediator.Send(new GetAllStockTypesQuery()));
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<StockTypeDto>> Get(Guid id)
        {
            return Ok(await Mediator.Send(new GetStockTypeQuery() { Id = id }));
        }

        [HttpPost]
        public async Task<ActionResult<CreateStockTypeCreated>> Post([FromBody]CreateStockTypeCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<StockTypeDto>> Put(Guid id, [FromBody]UpdateStockTypeCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<StockTypeDto>> Delete(Guid id)
        {
            return Ok(await Mediator.Send(new DeleteStockTypeCommand() { Id = id }));
        }
    }
}
