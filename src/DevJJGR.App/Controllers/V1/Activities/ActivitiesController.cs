using Donouts.Application.Activities.Commands.Create;
using Donouts.Application.Activities.Commands.Delete;
using Donouts.Application.Activities.Commands.Update;
using Donouts.Application.Activities.Queries.GetAll;
using Donouts.Application.Activities.Queries.GetById;
using Donouts.Application.Activities.Queries.GetByPredicate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Donouts.Controllers.V1.Activities;

//[Authorize(Roles = "Admin")]
public class ActivitiesController : BaseApiController
{
    [HttpGet("GetAll")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> GetAll([FromQuery] GetAllActivities request)
    {
        var response = await this.Mediator.Send(new GetAllActivities(pageNumber: request.PageNumber, pageSize: request.PageSize));
        return StatusCode((int)response.Code, response);
    }

    [HttpGet("GetByFilter")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> GetByFilter()
    {
        var response = await this.Mediator.Send(new GetByActivitiesPredicate());
        return StatusCode((int)response.Code, response);
    }

    [HttpGet("GetById")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> GetById(Guid Id)
    {
        var response = await this.Mediator.Send(new GetByIdActivities(Id));
        return StatusCode((int)response.Code, response);
    }

    [HttpPut("Create")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> Create(CreateActivitiesCommand command)
    {
        var response = await this.Mediator.Send(command);
        return StatusCode((int)response.Code, response);
    }

    [HttpPost("Update")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> Update(UpdateActivitiesCommand command)
    {
        var response = await this.Mediator.Send(command);
        return StatusCode((int)response.Code, response);
    }

    [HttpDelete("Delete")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> Delete(DeleteActivitiesCommand command)
    {
        var response = await this.Mediator.Send(command);
        return StatusCode((int)response.Code, response);
    }
}