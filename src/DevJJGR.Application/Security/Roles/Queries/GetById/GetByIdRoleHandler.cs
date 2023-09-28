using AutoMapper;
using Donouts.Application.Dto.Security;
using Donouts.Domain.Entities;
using DonoutsCore.Common.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;


namespace Donouts.Application.Security.Roles.Queries.GetById
{
    public class GetByIdRoleHandler : IRequestHandler<GetByIdRole, ResponseDto<RoleDTO>>
    {
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IMapper _mapper;
        private readonly ILogger<GetByIdRoleHandler> _logger;
        public GetByIdRoleHandler(RoleManager<ApplicationRole> roleManager, IMapper mapper, ILogger<GetByIdRoleHandler> logger)
        {
            this._roleManager = roleManager;
            this._mapper = mapper;
            this._logger = logger;
        }
        public async Task<ResponseDto<RoleDTO>> Handle(GetByIdRole request, CancellationToken cancellationToken)
        {
            var responseDto = new ResponseDto<RoleDTO>();
            try
            {
                var user = await _roleManager.FindByIdAsync(request.Id);
                if (user is null)
                {
                    responseDto.SetStatusError("No hay registros", StatusCode.NO_CONTENT);

                    return responseDto;
                }
                var data = user;
                responseDto.Data = this._mapper.Map<RoleDTO>(user);
                responseDto.SetStatusCode(StatusCode.OK);
                responseDto.Message = "Transacción exitosa";
                return responseDto;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "Error.");
                responseDto.SetStatusError("Error interno en el servidor", StatusCode.INTERNAL_SERVER_ERROR);

                return responseDto;
            }
        }
    }
}
