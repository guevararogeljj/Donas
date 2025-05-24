using Donouts.Application.DownloadFile.Command;
using Donouts.Application.DownloadFile.GetById;
using Microsoft.AspNetCore.Mvc;

namespace Donouts.Controllers.V1.Documents;

public class DocumentsController : BaseApiController
{
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [HttpGet("DownloadFile")]
    public async Task<ActionResult> DownloadFile(Guid Id)
    {
        var response = await this.Mediator.Send(new DownloadFileById { Id = Id });
        return StatusCode((int)response.Code, response);
    }
    [HttpPost("UploadFile")]
    //decorardor para subir un archivo max 5mb
    [RequestSizeLimit(5 * 1024 * 1024)]
    public async Task<ActionResult> UploadFile([FromForm] UploadFileCommand file)
    {
        if (file == null || file.File.Length == 0)
        {
            return BadRequest("No file selected");
        }
        var response = await this.Mediator.Send(new UploadFileCommand { File = file.File });
        return StatusCode((int)response.Code, response);
    }
}