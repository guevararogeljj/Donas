using Donouts.Application.MessageMQ.Queries.GetAll;
using Donouts.Application.MessageMQ.Queries.GetByIdChatMessages;
using Microsoft.AspNetCore.Mvc;

namespace Donouts.Controllers.V1.ChatMessages;

public class ChatMessagesController : BaseApiController
{
    [HttpGet("GetAll")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> GetAll([FromQuery] GetAllChatMessages request)
    {
        var response = await this.Mediator.Send(new GetAllChatMessages(pageNumber: request.PageNumber, pageSize: request.PageSize));
        return StatusCode((int)response.Code, response);
    }
    
    [HttpGet("GetById")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> GetById([FromQuery] GetByIdChatMessages request)
    {
        var response = await this.Mediator.Send(new GetByIdChatMessages(request.Id));
        return StatusCode((int)response.Code, response);
    }
}