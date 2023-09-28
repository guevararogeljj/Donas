using AutoMapper;
using Donouts.Application.utils;
using Donouts.Domain.Entities;
using DonoutsCore.Common.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;


namespace Donouts.Application.Security.Roles.Command.Create
{
    public class CreateRolesCommandHandler : IRequestHandler<CreateRolesCommand, ResponseDto<Boolean>>
    {
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateRolesCommandHandler> _logger;
        public CreateRolesCommandHandler(RoleManager<ApplicationRole> roleManager, IMapper mapper, ILogger<CreateRolesCommandHandler> logger)
        {
            this._roleManager = roleManager;
            this._mapper = mapper;
            this._logger = logger;
        }
        public async Task<ResponseDto<bool>> Handle(CreateRolesCommand request, CancellationToken cancellationToken)
        {
            var responseDto = new ResponseDto<Boolean>();
            try
            {
                var objDb = new ApplicationRole();
                objDb.Id = Guid.NewGuid();
                objDb.Name = request.Name;

                if (!await _roleManager.RoleExistsAsync(request.Name))
                    await _roleManager.CreateAsync(objDb);
                else
                {
                    responseDto.Message = "Rol existente";
                    responseDto.Data = false;
                    responseDto.SetStatusCode(StatusCode.BAD_REQUEST);
                    return responseDto;
                }

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
