
using System.Linq.Expressions;
using AutoMapper;
using Donouts.Application.Common.Interfaces;
using Donouts.Application.Dto.Calendar;
using Donouts.Domain.Entities.Calendario;
using DonoutsCore.Common.Models;
using LinqKit;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Donouts.Application.Calendar.Queries.GetByPredicate
{
	public class GetByCalendarPredicateHandler : IRequestHandler<GetByCalendarPredicate, ResponseDto<List<CalendarioActividadesDTO>>>
    {
        private readonly ILogger<GetByCalendarPredicateHandler> _logger;
        private readonly ICalendarRepository _calendarRepository;
        private readonly IMapper _mapper;
        public GetByCalendarPredicateHandler(ILogger<GetByCalendarPredicateHandler> logger, ICalendarRepository calendarRepository, IMapper mapper)
		{
            this._logger = logger;
            this._calendarRepository = calendarRepository;
            this._mapper = mapper;
		}

        public async Task<ResponseDto<List<CalendarioActividadesDTO>>> Handle(GetByCalendarPredicate request, CancellationToken cancellationToken)
        {
            var responseDto = new ResponseDto<List<CalendarioActividadesDTO>>();
            try
            {

                Expression<Func<CalendarioActividades, bool>>? predicate = null;
                if (request.HasFilter())
                {
                    predicate = this.GetFilter(request);
                }
                var activities = await this._calendarRepository.GetAllByPredicateAsync(predicate!);
                if (activities is null)
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

        private ExpressionStarter<CalendarioActividades> GetFilter(GetByCalendarPredicate query)
        {
            var predicate = PredicateBuilder.New<CalendarioActividades>(true);
            if (query.EventDate.HasValue)
            {
                predicate.And(x => x.EventDate.Equals(query.EventDate));
            }
            if (query.StartTime.HasValue)
            {
                predicate.And(x => x.StartTime.Equals(query.StartTime));
            }
            if (query.EndTime.HasValue)
            {
                predicate.And(x => x.EndTime.Equals(query.EndTime));
            }
            if (query.ClosedDate.HasValue)
            {
                predicate.And(x => x.ClosedDate.Equals(query.ClosedDate));
            }

            return predicate;
        }
    }
}

