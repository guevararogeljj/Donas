using AutoMapper;
using Donouts.Application.utils;
using Donouts.Domain.Entities;
using DonoutsCore.Common.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace Donouts.Application.Security.Roles.Command.Delete
{
    public class DeleteRolesCommandHandler : IRequestHandler<DeleteRolesCommand, ResponseDto<Boolean>>
    {
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteRolesCommandHandler> _logger;
        public DeleteRolesCommandHandler(RoleManager<ApplicationRole> roleManager, IMapper mapper, ILogger<DeleteRolesCommandHandler> logger)
        {
            this._roleManager = roleManager;
            this._mapper = mapper;
            this._logger = logger;
        }
        public async Task<ResponseDto<bool>> Handle(DeleteRolesCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<Boolean>();
            try
            {
                var roldb = (await this._roleManager.FindByIdAsync(request.Id));
                if (roldb == null)
                    return new ResponseDto<Boolean>("rol no existente.", StatusCode.BAD_REQUEST);

                if (await _roleManager.RoleExistsAsync(UserRoles.Admin))
                    await this._roleManager.DeleteAsync(roldb);
 
                response.Data = true;
                response.SetStatusCode(StatusCode.OK);

                return response;
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, "Error.");
                return new ResponseDto<Boolean>("Surgio un error.", StatusCode.INTERNAL_SERVER_ERROR);
            }
        }
    }
}
