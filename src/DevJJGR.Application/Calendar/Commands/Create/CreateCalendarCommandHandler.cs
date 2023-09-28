using AutoMapper;
using Donouts.Application.Common.Interfaces;
using Donouts.Domain.Entities.Calendario;
using DonoutsCore.Common.Models;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Donouts.Application.Calendar.Commands.Create
{
	public class CreateCalendarCommandHandler : IRequestHandler<CreateCalendarCommand, ResponseDto<Boolean>>
	{
        private readonly ILogger<CreateCalendarCommandHandler> _logger;
        private readonly ICalendarRepository _calendarRepository;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;
        public CreateCalendarCommandHandler(ILogger<CreateCalendarCommandHandler> logger, ICalendarRepository calendarRepository,
            IMapper mapper, ICurrentUserService currentUserService)
		{
            this._logger = logger;
            this._calendarRepository = calendarRepository;
            this._mapper = mapper;
            this._currentUserService = currentUserService;
		}

        public async Task<ResponseDto<bool>> Handle(CreateCalendarCommand request, CancellationToken cancellationToken)
        {
            var responseDto = new ResponseDto<Boolean>();
            try
            {
                var objDb = new CalendarioActividades();
                var userId = this._currentUserService.userId;
                objDb.ActivityId = request.ActivityId;
                objDb.EventDate = request.EventDate;
                objDb.StartTime = request.StartTime;
                objDb.EndTime = request.EndTime;
                objDb.Comments = request.Comments;
                objDb.ClosedDate = request.ClosedDate;
                objDb.Visible = true;
                objDb.CreatedAt = DateTime.Now;
                objDb.ModifiedAt = DateTime.Now;
                objDb.UserCreatedId = Guid.Parse(userId);
                await this._calendarRepository.AddAsync(objDb);
                await this._calendarRepository.SaveChangesAsync();
                responseDto.Data = true;
                responseDto.SetStatusCode(StatusCode.CREATED);
                responseDto.Message = "Transacción exitosa";
                return responseDto;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "Error.");
                responseDto.SetStatusError("Error interno en el servidor", StatusCode.INTERNAL_SERVER_ERROR);
                responseDto.Data = true;
                return responseDto;
            }
        }
    }
}

