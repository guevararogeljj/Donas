using System;
using AutoMapper;
using Donouts.Application.Common.Interfaces;
using DonoutsCore.Common.Models;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Donouts.Application.Security.Users.Command.Update
{
	public class UpdateUsersCommandHandler : IRequestHandler<UpdateUsersCommand, ResponseDto<Boolean>>
	{
        private readonly IUsersRepository _usersRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateUsersCommand> _logger;

        public UpdateUsersCommandHandler(IUsersRepository usersRepository, IMapper mapper, ILogger<UpdateUsersCommand> logger)
		{
            this._usersRepository = usersRepository;
            this._mapper = mapper;
            this._logger = logger;
		}

        public async Task<ResponseDto<bool>> Handle(UpdateUsersCommand request, CancellationToken cancellationToken)
        {
            var responseDto = new ResponseDto<Boolean>();
            try
            {
                var objDb = await _usersRepository.GetById(request.Id);
                if (objDb is null)
                {
                    responseDto.SetStatusError("No hay registros", StatusCode.NOT_FOUND);
                    return responseDto;
                }
                objDb.Name = request.Name;
                objDb.PhoneNumber = request.PhoneNumber;
                objDb.Email = request.Email;
                objDb.UserName = request.UserName;

                await _usersRepository.Update(objDb);
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

