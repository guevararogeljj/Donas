using Donouts.Application.Calendar.Commands.Create;
using Donouts.Application.Calendar.Commands.Delete;
using Donouts.Application.Calendar.Commands.Update;
using Donouts.Application.Calendar.Queries.GetAll;
using Donouts.Application.Calendar.Queries.GetAssigned;
using Donouts.Application.Calendar.Queries.GetById;
using Donouts.Application.Calendar.Queries.GetByPredicate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Donouts.Controllers.V1.Appointment;

public class CalendarController : BaseApiController
{
    [Authorize(Roles = "Admin")]
    [HttpGet("GetAll")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> GetAll([FromQuery] GetAllCalendar request)
    {
        var response = await this.Mediator.Send(new GetAllCalendar(pageNumber: request.PageNumber, pageSize: request.PageSize));
        return StatusCode((int)response.Code, response);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("GetAssigned")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> GetAssigned()
    {
        var response = await this.Mediator.Send(new GetCalendarAssigned());
        return StatusCode((int)response.Code, response);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("GetById")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> GetById([FromQuery] GetByIdCalendar request)
    {
        var response = await this.Mediator.Send(new GetByIdCalendar(id: request.Id));
        return StatusCode((int)response.Code, response);
    }

    [Authorize(Roles = "Admin")]
    [Authorize(Roles = "Cliente")]
    [HttpGet("GetByFilter")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> GetByFilter([FromQuery] GetByCalendarPredicate request)
    {
        var response = await this.Mediator.Send(new GetByCalendarPredicate());
        return StatusCode((int)response.Code, response);
    }

    [Authorize(Roles = "Admin")]
    [Authorize(Roles = "Cliente")]
    [HttpPut("Create")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> Create([FromBody] CreateCalendarCommand request)
    {
        var response = await this.Mediator.Send(new CreateCalendarCommand());
        return StatusCode((int)response.Code, response);
    }

    [Authorize(Roles = "Admin")]
    [Authorize(Roles = "Cliente")]
    [HttpPost("Update")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> Update([FromBody] UpdateCalendarCommand request)
    {
        var response = await this.Mediator.Send(new UpdateCalendarCommand());
        return StatusCode((int)response.Code, response);
    }

    [Authorize(Roles = "Admin")]
    [Authorize(Roles = "Cliente")]
    [HttpDelete("Delete")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> Delete([FromBody] DeleteCalendarCommand request)
    {
        var response = await this.Mediator.Send(new DeleteCalendarCommand());
        return StatusCode((int)response.Code, response);
    }
}