using Application.Features.Orders.Commands.Add;
using Application.Features.Orders.Commands.HardDelete;
using Application.Features.Orders.Commands.SoftDelete;
using Application.Features.Orders.Commands.UndoDelete;
using Application.Features.Orders.Queries.GetAll;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Authorize]
    public class OrdersController : ApiControllerBase
    {

        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync(OrderAddCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost("GetById")]
        public async Task<IActionResult> GetByIdAsync(OrderGetByIdQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpPost("GetAll")]
        public async Task<IActionResult> GetAllAsync(OrderGetAllQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpPut("SoftDelete")]
        public async Task<IActionResult> SoftDeleteAsync(OrderSoftDeleteCommand command)
        {

            return Ok(await Mediator.Send(command));

        }

        [HttpPut("UndoDelete")]
        public async Task<IActionResult> UndoDeleteAsync(OrderUndoDeleteCommand command)
        {

            return Ok(await Mediator.Send(command));

        }

        [HttpDelete("HardDelete")]
        public async Task<IActionResult> HardDeleteAsync(OrderHardDeleteCommand command)
        {

            return Ok(await Mediator.Send(command));

        }
    }
}
