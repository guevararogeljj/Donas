using System;
using AutoMapper;
using Donouts.Application.Activities.Queries.GetAll;
using Donouts.Application.Common.Interfaces;
using Donouts.Application.Dto.Activities;
using Donouts.Application.Dto.Calendar;
using DonoutsCore.Common.Models;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Donouts.Application.Calendar.Queries.GetAll
{
	public class GetAllCalendarHandler : IRequestHandler<GetAllCalendar, ResponseDto<List<CalendarioActividadesDTO>>>
    {
        private readonly ILogger<GetAllCalendarHandler> _logger;
        private readonly ICalendarRepository _calendarRepository;
        private readonly IMapper _mapper;
        public GetAllCalendarHandler(ILogger<GetAllCalendarHandler> logger, ICalendarRepository calendarRepository, IMapper mapper)
		{
            this._logger = logger;
            this._calendarRepository = calendarRepository;
            this._mapper = mapper;
		}

        public async Task<ResponseDto<List<CalendarioActividadesDTO>>> Handle(GetAllCalendar request, CancellationToken cancellationToken)
        {
            var responseDto = new ResponseDto<List<CalendarioActividadesDTO>>();
            try
            {
                var activities = await this._calendarRepository.GetAll(request.PageNumber, request.PageSize);
                if (activities.Count() <= 0)
                {
                    responseDto.SetStatusError("No hay registros", StatusCode.NO_CONTENT);
                    return responseDto;
                }
                var data = _mapper.Map<List<CalendarioActividadesDTO>>(activities);
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

