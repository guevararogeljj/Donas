using System;
using AutoMapper;
using Donouts.Application.Activities.Commands.Delete;
using Donouts.Application.Common.Interfaces;
using Donouts.Domain.Entities.Calendario;
using DonoutsCore.Common.Models;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Donouts.Application.Calendar.Commands.Delete
{
	public class DeleteCalendarCommandHandler : IRequestHandler<DeleteCalendarCommand, ResponseDto<Boolean>>
    {
        private readonly ILogger<DeleteCalendarCommandHandler> _logger;
        private readonly ICalendarRepository _calendarRepository;
        private readonly IMapper _mapper;

        public DeleteCalendarCommandHandler(ILogger<DeleteCalendarCommandHandler> logger, ICalendarRepository calendarRepository, IMapper mapper)
		{
            this._logger = logger;
            this._calendarRepository = calendarRepository;
            this._mapper = mapper;
		}

        public async Task<ResponseDto<bool>> Handle(DeleteCalendarCommand request, CancellationToken cancellationToken)
        {
            var responseDto = new ResponseDto<Boolean>();
            try
            {
                var objDb = await this._calendarRepository.GetById(request.Id);
                if (objDb is null)
                {
                    responseDto.SetStatusError("No hay registros", StatusCode.NOT_FOUND);
                    return responseDto;
                }
                var data = _mapper.Map<CalendarioActividades>(objDb);
                this._calendarRepository.Delete(data);
                await _calendarRepository.SaveChangesAsync();
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

