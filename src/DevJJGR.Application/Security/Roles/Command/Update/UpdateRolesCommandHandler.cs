using AutoMapper;
using DonoutsCore.Common.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;


namespace Donouts.Application.Security.Roles.Command.Update
{
    public class UpdateRolesCommandHandler : IRequestHandler<UpdateRolesCommand, ResponseDto<Boolean>>
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<UpdateRolesCommandHandler> _logger;
        public UpdateRolesCommandHandler(RoleManager<IdentityRole> roleManager, ILogger<UpdateRolesCommandHandler> logger)
        {
            this._roleManager = roleManager;
            this._logger = logger;
        }
        public async Task<ResponseDto<bool>> Handle(UpdateRolesCommand request, CancellationToken cancellationToken)
        {
            var responseDto = new ResponseDto<Boolean>();
            try
            {
                var objDb = await _roleManager.FindByIdAsync(request.Id);
                if (objDb is null)
                {
                    responseDto.SetStatusError("No hay registros", StatusCode.NOT_FOUND);
                    return responseDto;
                }
                objDb.Name = request.Name;


                await _roleManager.UpdateAsync(objDb);
                responseDto.Data = true;
                responseDto.SetStatusCode(StatusCode.OK);
                responseDto.Message = "Transacción exitosa";
                return responseDto;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "Error.");
                responseDto.SetStatusError("Error interno en el servidor", StatusCode.INTERNAL_SERVER_ERROR);
                responseDto.Data = false;
                return responseDto;
            }
        }
    }
}
