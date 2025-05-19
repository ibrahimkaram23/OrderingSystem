using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrderingSystem.Api.Base;
using OrderingSystem.Core.Features.Orders.Commands.Models;
using OrderingSystem.Core.Features.Orders.Queries.Models;
using OrderingSystem.Data.AppMetaData;

namespace OrderingSystem.Api.Controllers
{
    [Authorize]
    public class OrdersController : AppControllerBase
    {
        [HttpGet(Router.OrdersRoute.GetByID)]
        public async Task<IActionResult> GetOrderById([FromRoute] int id)
        {
            var response = await Mediator.Send(new GetOrderByIdQuery(id));
            return NewResult(response);
        }
        [HttpPost(Router.OrdersRoute.Create)]
        public async Task<IActionResult> Create([FromBody] CreateOrderCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        [HttpPut(Router.OrdersRoute.EditStatus)]
        public async Task<IActionResult> EditStatus([FromBody] UpdateOrderStatusCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
    }
}
