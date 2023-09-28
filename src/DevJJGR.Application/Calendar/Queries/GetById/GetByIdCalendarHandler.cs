using AutoMapper;
using Donouts.Application.Common.Interfaces;
using Donouts.Application.Dto.Calendar;
using DonoutsCore.Common.Models;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Donouts.Application.Calendar.Queries.GetById
{
	public class GetByIdCalendarHandler : IRequestHandler<GetByIdCalendar, ResponseDto<CalendarioActividadesDTO>>
    {
        private readonly ILogger<GetByIdCalendarHandler> _logger;
        private readonly ICalendarRepository _calendarRepository;
        private readonly IMapper _mapper;
        public GetByIdCalendarHandler(ILogger<GetByIdCalendarHandler> logger, ICalendarRepository calendarRepository, IMapper mapper)
		{
            this._logger = logger;
            this._calendarRepository = calendarRepository;
            this._mapper = mapper;
		}

        public async Task<ResponseDto<CalendarioActividadesDTO>> Handle(GetByIdCalendar request, CancellationToken cancellationToken)
        {
            var responseDto = new ResponseDto<CalendarioActividadesDTO>();
            try
            {
                var calendarDB = await this._calendarRepository.GetById(request.Id);
                if (calendarDB is null)
                {
                    responseDto.SetStatusError("No hay registros", StatusCode.NO_CONTENT);

                    return responseDto;
                }
                var data = _mapper.Map<CalendarioActividadesDTO>(calendarDB);
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

