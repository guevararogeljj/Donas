
using AutoMapper;
using Donouts.Application.Common.Interfaces;
using Donouts.Application.Dto;
using Donouts.Application.Dto.Security;
using DonoutsCore.Common.Models;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Donouts.Application.Security.Users.Queries.GetAll
{
	public class GetAllUsersHandler : IRequestHandler<GetAllUsers, ResponseDto<List<UsersDTO>>>
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetAllUsersHandler> _logger;
        public GetAllUsersHandler(IUsersRepository usersRepository, IMapper mapper,
            ILogger<GetAllUsersHandler>  logger)
		{
            this._usersRepository = usersRepository;
            this._mapper = mapper;
            this._logger = logger;
		}

        public async  Task<ResponseDto<List<UsersDTO>>> Handle(GetAllUsers request, CancellationToken cancellationToken)
        {
            var responseDto = new ResponseDto<List<UsersDTO>>();
            try
            {
                var users = await _usersRepository.GetAll();
                if (users.Count() <= 0)
                {
                    responseDto.SetStatusError("No hay registros", StatusCode.NO_CONTENT);

                    return responseDto;
                }
                var data = _mapper.Map<List<UsersDTO>>(users);
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

