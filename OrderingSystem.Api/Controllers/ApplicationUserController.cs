﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderingSystem.Api.Base;
using OrderingSystem.Core.Features.ApplicationUser.Commands.Models;
using OrderingSystem.Core.Features.ApplicationUser.Queries.Models;
using OrderingSystem.Data.AppMetaData;

namespace OrderingSystem.Api.Controllers
{
    [ApiController]
    [Authorize(Roles ="Admin")]
    public class ApplicationUserController : AppControllerBase
    {
        [HttpPost(Router.ApplicationUserRouting.Create)]
        public async Task<IActionResult> Create([FromBody] AddUserCommand command)
        {
            var response= await Mediator.Send(command);
            return NewResult(response);

        }
        [HttpGet(Router.ApplicationUserRouting.Paginted)]
        public async Task<IActionResult> Paginted([FromQuery] GetUserPaginationQuery query)
        {
            var response = await Mediator.Send(query);
            return Ok(response);

        }

        [HttpGet(Router.ApplicationUserRouting.GetByID)]
        public async Task<IActionResult> GetUserByID([FromRoute] int id)
        {

            return NewResult(await Mediator.Send(new GetUserByIdQuery(id)));

        }
        [HttpPut(Router.ApplicationUserRouting.Edit)]
        public async Task<IActionResult> Edit([FromBody] EditUserCommand command)
        {

            return NewResult(await Mediator.Send(command));

        }
        [HttpDelete(Router.ApplicationUserRouting.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {

            return NewResult(await Mediator.Send(new DeleteUserCommand(id)));

        }
        [HttpPut(Router.ApplicationUserRouting.ChangePassword)]
        public async Task<IActionResult> ChangePassword([FromBody] ChangeUserPasswordCommand command)
        {

            return NewResult(await Mediator.Send(command));

        }

    }
}
