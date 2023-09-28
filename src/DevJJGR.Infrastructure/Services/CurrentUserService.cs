using Donouts.Application.Common.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Donouts.Infrastructure.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _configuration;

        public CurrentUserService(
            IHttpContextAccessor httpContextAccessor,
            IConfiguration configuration
        )
        {
            this._httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException();
            _configuration = configuration;
        }

        public string userId => this._httpContextAccessor.HttpContext.User.FindFirst("user_id")!.Value;

        public bool IsAuthenticated => this._httpContextAccessor.HttpContext.User.Identity!.IsAuthenticated;

        public string GetClaimByType(string type)
        {
            var _Claim = this._httpContextAccessor?.HttpContext?.User?.Claims?.FirstOrDefault(x => x.Type == type);
            return _Claim?.Value ?? string.Empty;
        }
    }
}
