
using AutoMapper;
using Donouts.Application.utils;
using Donouts.Domain.Entities;
using DonoutsCore.Common.Models;
using MediatR;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace Donouts.Application.Security.Users.Command.Create
{
	public class CreateUsersCommandHandler : IRequestHandler<CreateUsersCommand, ResponseDto<Boolean>>
	{
        private readonly Microsoft.AspNetCore.Identity.UserManager<ApplicationUser> _userManager;
        private readonly Microsoft.AspNetCore.Identity.RoleManager<ApplicationRole> _roleManager;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateUsersCommandHandler> _logger;
        public CreateUsersCommandHandler(Microsoft.AspNetCore.Identity.UserManager<ApplicationUser> userManager,
         Microsoft.AspNetCore.Identity.RoleManager<ApplicationRole> roleManager,IMapper mapper, ILogger<CreateUsersCommandHandler> logger)
		{
            this._userManager = userManager;
            this._roleManager = roleManager;
            this._mapper = mapper;
            this._logger = logger;
		}

        public async Task<ResponseDto<bool>> Handle(CreateUsersCommand request, CancellationToken cancellationToken)
        {
            var responseDto = new ResponseDto<Boolean>();
            try
            {
                var userExists = await _userManager.FindByNameAsync(request.UserName);
                if (userExists != null)
                {
                    responseDto.Data = false;
                    responseDto.SetStatusCode(StatusCode.BAD_REQUEST);
                    return responseDto;
                }

                ApplicationUser user = new()
                {
                    Email = request.Email,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = request.UserName,
                    Name = request.Name,
                    Direction = request.Direction,
                    PhoneNumber = request.PhoneNumber,
                    CreatedAt = DateTime.Now,
                    ModifiedAt = DateTime.Now,
                };
                var createUserResult = await _userManager.CreateAsync(user, request.PasswordHash);

                var roleDb = (this._roleManager.FindByIdAsync(request.RoleId.ToString())).Result;
  
                if (roleDb is not null)
                    await _userManager.AddToRoleAsync(user, roleDb!.Name!);

                responseDto.Data = true;
                responseDto.SetStatusCode(StatusCode.CREATED);
                responseDto.Message = "Transacción exitosa";
                return responseDto;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "Error.");
                responseDto.SetStatusError("Error interno en el servidor", StatusCode.INTERNAL_SERVER_ERROR);
                responseDto.Data = true;
                return responseDto;
            }
        }
    }
}

