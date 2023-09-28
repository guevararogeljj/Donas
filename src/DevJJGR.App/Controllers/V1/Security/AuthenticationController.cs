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
            if (!ModelState.IsValid)
                return BadRequest("Datos no validos");
            var response = await _authService.Login(model);
            return StatusCode((int)response.Code, response);
        }
    }
}
