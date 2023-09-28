using System;
using AutoMapper;
using Donouts.Application.Calendar.Commands.Create;
using Donouts.Application.Common.Interfaces;
using DonoutsCore.Common.Models;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Donouts.Application.Calendar.Commands.Update
{
	public class UpdateCalendarCommandHandler : IRequestHandler<UpdateCalendarCommand, ResponseDto<Boolean>>
    {
        private readonly ILogger<UpdateCalendarCommandHandler> _logger;
        private readonly ICalendarRepository _calendarRepository;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;
        public UpdateCalendarCommandHandler(ILogger<UpdateCalendarCommandHandler> logger, ICalendarRepository calendarRepository,
            IMapper mapper, ICurrentUserService currentUserService)
		{
            this._logger = logger;
            this._calendarRepository = calendarRepository;
            this._mapper = mapper;
            this._currentUserService = currentUserService;
        }

        public async Task<ResponseDto<bool>> Handle(UpdateCalendarCommand request, CancellationToken cancellationToken)
        {
            var responseDto = new ResponseDto<Boolean>();
            try
            {
                var userCurrent = this._currentUserService.userId;

                var objDb = await this._calendarRepository.GetById(request.Id);
                if (objDb is null)
                {
                    responseDto.SetStatusError("No hay registros", StatusCode.NOT_FOUND);
                    return responseDto;
                }
                objDb.ModifiedAt = DateTime.Now;
                objDb.Comments = !string.IsNullOrEmpty(request.Comments) ? request.Comments : objDb.Comments;
                objDb.ActivityId = request.ActivityId;
                objDb.EventDate = request.EventDate;
                objDb.UserModifiedId = Guid.Parse(userCurrent);
                objDb.StartTime = request.StartTime;
                objDb.EndTime = request.EndTime;
                objDb.ClosedDate = request.ClosedDate.HasValue ? request.ClosedDate : objDb.ClosedDate;
                objDb.IsDeleted = request.IsDeleted.HasValue ? request.IsDeleted.Value : objDb.Visible;
                await this._calendarRepository.SaveChangesAsync();
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

