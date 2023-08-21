using Azure;
using Donouts.Application.Common.Interfaces;
using Donouts.Application.utils;
using Donouts.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Donouts.Presentation.Controllers.V1.Security
{
    [ApiVersion("1.0")]
    public class AuthenticationController : BaseApiController
    {
        private readonly IAuthService _authService;
        private readonly ILogger<AuthenticationController> _logger;
        public AuthenticationController(IAuthService authService, ILogger<AuthenticationController> logger)
        {
            _authService = authService;
            _logger = logger;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Datos no validos");
                var (status, message) = await _authService.Login(model);
                if (status == 0)
                    return BadRequest(message);
                return Ok(message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
