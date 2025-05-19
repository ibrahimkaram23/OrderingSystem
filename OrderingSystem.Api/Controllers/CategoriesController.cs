using OrderingSystem.Api.Base;
using OrderingSystem.Core.Features.Categories.Commands.Models;
using OrderingSystem.Core.Features.Categories.Queries.Models;
using OrderingSystem.Data.AppMetaData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OrderingSystem.Api.Controllers
{
    [Authorize]
    public class CategoriesController : AppControllerBase
    {
        [HttpGet(Router.CategoriesRoute.Categories)]
        public async Task<IActionResult> GetCategories([FromQuery] GetCategoriesQuery query)
        {
            var result = await Mediator.Send(query);
            return NewResult(result);
        }
        
        [HttpPost(Router.CategoriesRoute.Create)]
        public async Task<IActionResult> CreateCategory([FromBody] AddCategoryCommand query)
        {
            var result = await Mediator.Send(query);
            return NewResult(result);
        }
    }
}
