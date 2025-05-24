using Donouts.Application.Common.Interfaces;
using Donouts.Application.Dto.Security;
using Donouts.Application.utils;
using Donouts.Domain.Entities;
using Donouts.Persistance.Repository.Security.Common;
using DonoutsCore.Common.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Donouts.Persistance.Repository.Security.Auth
{
    public class AuthService: IAuthService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<ApplicationRole> roleManager;
        private readonly IConfiguration _configuration;
        public AuthService(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this._configuration = configuration;

        }
        public async Task<ResponseDto<TokenResponseDTO>> Login(LoginModel model)
        {
            var responseDto = new ResponseDto<TokenResponseDTO>();
            var user = await userManager.FindByNameAsync(model.Username);
            if (user == null)
            {
                responseDto.SetStatusError("Usuario inválido", StatusCode.NO_CONTENT);
                return responseDto;
            }
            if (!await userManager.CheckPasswordAsync(user, model.Password))
            {
                responseDto.SetStatusError("Password invalido", StatusCode.BAD_REQUEST);
                return responseDto;
            }

            var userRoles = await userManager.GetRolesAsync(user);
            var authClaims = new List<Claim>
            {
               new Claim(ClaimTypes.Name, user.Name),
               new Claim(ExtendedClaimTypes.IdUser, user.Id.ToString()),
               new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }
            string token = GenerateToken(authClaims);
            var tokenResponse = new TokenResponseDTO();
            tokenResponse.Token = token;
            tokenResponse.Role = userRoles.FirstOrDefault();
            responseDto.Data = tokenResponse;
            responseDto.SetStatusCode(StatusCode.OK);
            responseDto.Message = "Transacción exitosa";
            return responseDto;
        }


        private string GenerateToken(IEnumerable<Claim> claims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWTKey:Secret"]));
            var TokenExpiryTimeInMinutes = Convert.ToInt64(_configuration["JWTKey:TokenExpiryTimeInMinutes"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _configuration["JWTKey:ValidIssuer"],
                Audience = _configuration["JWTKey:ValidAudience"],
                Expires = DateTime.UtcNow.AddMinutes(TokenExpiryTimeInMinutes),
                SigningCredentials = new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256),
                Subject = new ClaimsIdentity(claims)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
