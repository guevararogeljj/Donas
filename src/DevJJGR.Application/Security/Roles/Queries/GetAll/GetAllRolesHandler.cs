using AutoMapper;
using Donouts.Application.Dto.Security;
using Donouts.Domain.Entities;
using DonoutsCore.Common.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;


namespace Donouts.Application.Security.Roles.Queries.GetAll
{
    public class GetAllRolesHandler : IRequestHandler<GetAllRoles, ResponseDto<List<RoleDTO>>>
    {
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IMapper _mapper;
        private readonly ILogger<GetAllRolesHandler> _logger;
        public GetAllRolesHandler(RoleManager<ApplicationRole> roleManager, IMapper mapper, ILogger<GetAllRolesHandler> logger)
        {
            this._roleManager = roleManager;
            this._mapper = mapper;
            this._logger = logger;
        }
        public async Task<ResponseDto<List<RoleDTO>>> Handle(GetAllRoles request, CancellationToken cancellationToken)
        {
            var responseDto = new ResponseDto<List<RoleDTO>>();
            try
            {
                var roles = this._roleManager.Roles.ToList();
                if (roles.Count() <= 0)
                {
                    responseDto.SetStatusError("No hay registros", StatusCode.NO_CONTENT);

                    return responseDto;
                }
                var data = this._mapper.Map<List<RoleDTO>>(roles);
                responseDto.Data = data;
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
