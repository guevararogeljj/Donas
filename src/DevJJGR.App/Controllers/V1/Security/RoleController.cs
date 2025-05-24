using Donouts.Application.Dto.Security;
using Donouts.Application.Security.Roles.Command.Create;
using Donouts.Application.Security.Roles.Command.Delete;
using Donouts.Application.Security.Roles.Command.Update;
using Donouts.Application.Security.Roles.Queries.GetAll;
using Donouts.Application.Security.Roles.Queries.GetById;
using Donouts.Controllers;
using DonoutsCore.Common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Donouts.Presentation.Controllers.V1.Security
{
    [ApiVersion("1.0")]
    [Authorize(Roles = "Admin")]
    public class RoleController : BaseApiController
    {
        [HttpGet("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetAll([FromQuery] GetAllRoles request)
        {
            var response = await this.Mediator.Send(new GetAllRoles(request.PageNumber, request.PageNumber));
            return StatusCode((int)response.Code, response);
        }

        [HttpGet("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetById(Guid Id)
        {
            var response = await this.Mediator.Send(new GetByIdRole { Id = Id.ToString() });
            return StatusCode((int)response.Code, response);
        }

        [HttpPost]
        [Route("Save")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ResponseDto<UsersDTO>>> Save(CreateRolesCommand request)
        {
            var result = await Mediator.Send(request);
            return StatusCode((int)result.Code, result);
        }

        [HttpPut]
        [Route("Update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ResponseDto<UsersDTO>>> Update(UpdateRolesCommand request)
        {
            var result = await Mediator.Send(request);
            return StatusCode((int)result.Code, result);
        }

        [HttpDelete]
        [Route("Delete/{Id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Delete(Guid Id)
        {
            var response = await this.Mediator.Send(new DeleteRolesCommand { Id = Id.ToString() });
            return StatusCode((int)response.Code, response);
        }
    }
}
