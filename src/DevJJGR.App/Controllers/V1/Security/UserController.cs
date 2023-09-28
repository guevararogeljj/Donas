
using Donouts.Application.Dto.Security;
using Donouts.Application.Security.Users.Command.Create;
using Donouts.Application.Security.Users.Command.Delete;
using Donouts.Application.Security.Users.Command.Update;
using Donouts.Application.Security.Users.Queries.GetAll;
using Donouts.Application.Security.Users.Queries.GetById;
using Donouts.Controllers;
using DonoutsCore.Common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Donouts.Presentation.Controllers.V1.Security
{
    [ApiVersion("1.0")]
    public class UserController : BaseApiController
    {
        [Authorize(Roles = "Admin")]
        [HttpGet("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetAll()
        {
            var response = await this.Mediator.Send(new GetAllUsers());
            return StatusCode((int)response.Code, response);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetById(Guid Id)
        {
            var response = await this.Mediator.Send(new GetByIdUsers { Id = Id });
            return StatusCode((int)response.Code, response);
        }
        [Authorize(Roles = "Admin")]
        [Authorize(Roles = "Cliente")]
        [HttpPost]
        [Route("Save")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ResponseDto<UsersDTO>>> Save(CreateUsersCommand request)
        {
            var result = await Mediator.Send(request);
            return StatusCode((int)result.Code, result);
        }
        [Authorize(Roles = "Admin")]
        [Authorize(Roles = "Cliente")]
        [HttpPut]
        [Route("Update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ResponseDto<UsersDTO>>> Update(UpdateUsersCommand request)
        {
            var result = await Mediator.Send(request);
            return StatusCode((int)result.Code, result);
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete]
        [Route("Delete/{Id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Delete(Guid Id)
        {
            var response = await this.Mediator.Send(new DeleteUsersCommand { Id = Id });
            return StatusCode((int)response.Code, response);
        }
    }
}

