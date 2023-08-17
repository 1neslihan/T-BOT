using Application.Features.Products.Commands.Add;
using Application.Features.Products.Queries.GetAll;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Authorize]
    public class ProductsController : ApiControllerBase
    {
        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync(ProductAddCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost("GetAll")]
        public async Task<IActionResult> GetAllAsync(ProductGetAllQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetByOrderIdAsync(bool isDeleted, Guid orderId, int pageNumber = 1, int pageSize = 10)
        {
            return Ok(await Mediator.Send(new ProductGetByOrderIdQuery(isDeleted, orderId, pageNumber, pageSize)));
        }

        //[HttpGet("Pull/{id}")]
        //public async Task<IActionResult> GetByIdAsync(Guid id)
        //{
        //    return Ok(await Mediator.Send(new ProductGetAllQuery(id, null)));
        //}
    }
}
