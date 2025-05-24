using Donouts.Application.Donnouts.Sales.Commands.Create;
using Donouts.Application.Donnouts.Sales.Queries.GetAll;
using Donouts.Application.Donnouts.Sales.Queries.GetById;
using Donouts.Application.Donnouts.Sales.Queries.GetByPredicate;
using Donouts.Application.Dto.Security;
using Donouts.Controllers;
using DonoutsCore.Common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Donouts.Presentation.Controllers.V1.Donouts.SalesDonouts
{
    [ApiVersion("1.0")]
    
    public class SalesDonoutsController : BaseApiController
    {
        [HttpGet("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetAll()
        {
            var response = await this.Mediator.Send(new GetAllSalesDonouts());
            return StatusCode((int)response.Code, response);
        }

        [HttpGet("GetAllQuery")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetAllQuery(Guid Id)
        {
            var response = await this.Mediator.Send(new GetByPredicate { TypeDonoutId = Id });
            return StatusCode((int)response.Code, response);
        }

        [HttpGet("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetById(Guid Id)
        {
            var response = await this.Mediator.Send(new GetByIdSalesDonouts { Id = Id });
            return StatusCode((int)response.Code, response);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("Save")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ResponseDto<UsersDTO>>> Save(CreateSalesDonoutsCommand request)
        {
            var result = await Mediator.Send(request);
            return StatusCode((int)result.Code, result);
        }

        [HttpGet("GetByType")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetByType(GetByPredicate model)
        {
            var response = await this.Mediator.Send(model);
            return StatusCode((int)response.Code, response);
        }
    }
}
