using System;
using System.Linq.Expressions;
using AutoMapper;
using Donouts.Application.Calendar.Queries.GetByPredicate;
using Donouts.Application.Common.Interfaces;
using Donouts.Application.Dto.Calendar;
using Donouts.Domain.Entities.Calendario;
using DonoutsCore.Common.Models;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Donouts.Application.Calendar.Queries.GetAssigned
{
	public class GetCalendarAssignedHandler : IRequestHandler<GetCalendarAssigned, ResponseDto<List<CalendarioActividadesDTO>>>
    {
        private readonly ILogger<GetCalendarAssignedHandler> _logger;
        private readonly ICalendarRepository _calendarRepository;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;
        public GetCalendarAssignedHandler(ILogger<GetCalendarAssignedHandler> logger, ICalendarRepository calendarRepository,
            IMapper mapper, ICurrentUserService currentUserService)
		{
            this._logger = logger;
            this._calendarRepository = calendarRepository;
            this._mapper = mapper;
            this._currentUserService = currentUserService;
		}

        public async Task<ResponseDto<List<CalendarioActividadesDTO>>> Handle(GetCalendarAssigned request, CancellationToken cancellationToken)
        {
            var responseDto = new ResponseDto<List<CalendarioActividadesDTO>>();
            try
            {
                Expression<Func<CalendarioActividades, bool>>? predicate = null;
                var userId = this._currentUserService.userId;
                predicate = x => x.UserCreatedId.Equals(Guid.Parse(userId));
                var calendarDB = await this._calendarRepository.GetAllByPredicateAsync(predicate!);
                
                if (calendarDB is null)
                {
                    responseDto.SetStatusError("No hay registros", StatusCode.NO_CONTENT);

                    return responseDto;
                }
                var data = _mapper.Map<List<CalendarioActividadesDTO>>(calendarDB);
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

