using Donouts.Application.Donnouts.Types.Commands.Create;
using Donouts.Application.Donnouts.Types.Commands.Delete;
using Donouts.Application.Donnouts.Types.Commands.Update;
using Donouts.Application.Donnouts.Types.Queries.GetAll;
using Donouts.Application.Donnouts.Types.Queries.GetById;
using Donouts.Application.Dto.Security;
using Donouts.Application.Security.Roles.Queries.GetById;
using Donouts.Controllers;
using DonoutsCore.Common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Donouts.Presentation.Controllers.V1.Donouts.TypeDonouts
{
    [ApiVersion("1.0")]

    public class TypeDonoutsController : BaseApiController
    {
        [HttpGet("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetAll()
        {
            var response = await this.Mediator.Send(new GetAllTypeDonouts());
            return StatusCode((int)response.Code, response);
        }

        [HttpGet("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetById(Guid Id)
        {
            var response = await this.Mediator.Send(new GetByIdTypeDonouts { Id = Id });
            return StatusCode((int)response.Code, response);
        }
        //[Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("Save")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ResponseDto<UsersDTO>>> Save(CreateTypeDonoutsCommand request)
        {
            var result = await Mediator.Send(request);
            return StatusCode((int)result.Code, result);
        }
        ///[Authorize(Roles = "Admin")]
        [HttpPut]
        [Route("Update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ResponseDto<UsersDTO>>> Update(UpdateTypeDonoutsCommand request)
        {
            var result = await Mediator.Send(request);
            return StatusCode((int)result.Code, result);
        }
        //[Authorize(Roles = "Admin")]
        [HttpDelete]
        [Route("Delete/{Id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Delete(Guid Id)
        {
            var response = await this.Mediator.Send(new DeleteTypeDonoutsCommand { Id = Id });
            return StatusCode((int)response.Code, response);
        }
    }
}
