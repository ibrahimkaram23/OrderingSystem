using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrderingSystem.Api.Base;
using OrderingSystem.Core.Features.ApplicationUser.Commands.Models;
using OrderingSystem.Core.Features.Customers.Queries.Models;
using OrderingSystem.Data.AppMetaData;

namespace OrderingSystem.Api.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CustomersController : AppControllerBase
    {
        [HttpGet(Router.CustomersRoute.GetCustomers)]
        public async Task<IActionResult> GetCustomers([FromQuery] GetAllCustomersQuery query)
        {
            var result = await Mediator.Send(query);
            return NewResult(result);
        }
        [HttpPost(Router.CustomersRoute.Create)]
        public async Task<IActionResult> CreateCustomer([FromBody] AddUserCommand command)
        {
            var result = await Mediator.Send(command);
            return NewResult(result);
        }
        [HttpGet(Router.CustomersRoute.GetByID)]
        public async Task<IActionResult> GetCustomerByID([FromRoute] int id)
        {
            return NewResult(await Mediator.Send(new GetCustomerByIdQuery{ Id = id }));
        }
    }
}
