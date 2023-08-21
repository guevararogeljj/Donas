using System.Linq.Expressions;
using AutoMapper;
using Donouts.Application.Common.Interfaces;
using Donouts.Application.Dto;
using Donouts.Application.Dto.Security;
using Donouts.Application.Security.Users.Queries.GetAll;
using DonoutsCore.Common.Models;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Donouts.Application.Security.Users.Queries.GetById
{
	public class GetByIdUsersHandler : IRequestHandler<GetByIdUsers, ResponseDto<UsersDTO>>
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetByIdUsersHandler> _logger;
        public GetByIdUsersHandler(IUsersRepository usersRepository, IMapper mapper, ILogger<GetByIdUsersHandler> logger)
		{
            this._usersRepository = usersRepository;
            this._mapper = mapper;
            this._logger = logger;
		}

        public async Task<ResponseDto<UsersDTO>> Handle(GetByIdUsers request, CancellationToken cancellationToken)
        {
            var responseDto = new ResponseDto<UsersDTO>();
            try
            {
                Expression<Func<Domain.Entities.ApplicationUser, bool>>? predicate = null;
                predicate = x => x.Id.Equals(request.Id);
                var user = await _usersRepository.GetAllByPredicateAsync(predicate);
                if (user.Count() <= 0)
                {
                    responseDto.SetStatusError("No hay registros", StatusCode.NO_CONTENT);

                    return responseDto;
                }
                var data = user;
                responseDto.Data = data.FirstOrDefault()!;
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

