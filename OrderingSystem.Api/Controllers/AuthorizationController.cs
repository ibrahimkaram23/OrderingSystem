using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrderingSystem.Api.Base;
using OrderingSystem.Core.Features.Authorization.Commands.Models;
using OrderingSystem.Core.Features.Authorization.Queries.Models;
using OrderingSystem.Data.AppMetaData;
using Swashbuckle.AspNetCore.Annotations;

namespace OrderingSystem.Api.Controllers
{
   
    [ApiController]
    [Authorize(Roles ="Admin")]
    public class AuthorizationController : AppControllerBase
    {
        [HttpPost(Router.AuthorizationRouting.Create)]
        public async Task<IActionResult> Create([FromForm] AddRoleCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);

        }
        [HttpPost(Router.AuthorizationRouting.Edit)]
        public async Task<IActionResult> Edit([FromForm] EditRoleCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);

        }
        [HttpDelete(Router.AuthorizationRouting.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var response = await Mediator.Send(new DeleteRoleCommand(id));
            return NewResult(response);

        }
        [HttpGet(Router.AuthorizationRouting.RoleList)]
        public async Task<IActionResult> GetRoleList()
        {
            var response = await Mediator.Send(new GetRolesListQuery());
            return Ok(response);

        }
        [SwaggerOperation(OperationId = "RoleById")]
        [HttpGet(Router.AuthorizationRouting.GetRoleById)]
        public async Task<IActionResult> GetRoleById([FromRoute] int id)
        {
            var response = await Mediator.Send(new GetRoleByIdQuery()
            {
                Id = id
            });
            return Ok(response);

        }
        [SwaggerOperation(Summary = "Manage Users Roles", OperationId = "ManageUserRoles")]
        [HttpGet(Router.AuthorizationRouting.ManageUserRoles)]
        public async Task<IActionResult> ManageUserRoles([FromRoute] int userId)
        {
            var response = await Mediator.Send(new ManageUserRoleQuery()
            {
               UserId = userId
            });
            return NewResult(response);

        }
        [SwaggerOperation(Summary = "Edit Users Roles", OperationId = "UpdateUserRoles")]
        [HttpPut(Router.AuthorizationRouting.UpdateUserRoles)]
        public async Task<IActionResult> UpdateUserRoles([FromBody] UpdateUserRolesCommand command)
        {
            var response = await Mediator.Send( command);
    
         
            return NewResult(response);

        }
        [SwaggerOperation(Summary = "Manage Users Privileges", OperationId = "ManageUserClaim")]
        [HttpGet(Router.AuthorizationRouting.ManageUserClaims)]
        public async Task<IActionResult> ManageUserClaims([FromRoute] int userId)
        {
            var response = await Mediator.Send(new ManageUserClaimsQuery()
            {
                UserId = userId
            });
            return NewResult(response);

        }
        [SwaggerOperation(Summary = "Edit Users Privileges", OperationId = "UpdateUserClaims")]
        [HttpPut(Router.AuthorizationRouting.UpdateUserClaims)]
        public async Task<IActionResult> UpdateUserClaims([FromBody] UpdateUserClaimsCommand command)
        {
            var response = await Mediator.Send(command);


            return NewResult(response);

        }
    }
}
