using System;
using AutoMapper;
using Donouts.Application.Activities.Commands.Create;
using Donouts.Application.Common.Interfaces;
using DonoutsCore.Common.Models;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Donouts.Application.Activities.Commands.Update
{
    public class UpdateActivitiesHandler : IRequestHandler<UpdateActivitiesCommand, ResponseDto<Boolean>>
    {
        private readonly ILogger<UpdateActivitiesHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IActivitiesRepository _activitiesRepository;
        public UpdateActivitiesHandler(ILogger<UpdateActivitiesHandler> logger, IMapper mapper, IActivitiesRepository activitiesRepository)
        {
            this._logger = logger;
            this._mapper = mapper;
            this._activitiesRepository = activitiesRepository;
        }
        public async Task<ResponseDto<bool>> Handle(UpdateActivitiesCommand request, CancellationToken cancellationToken)
        {
            var responseDto = new ResponseDto<Boolean>();
            try
            {
                var objDb = await this._activitiesRepository.GetById(request.Id);
                if (objDb is null)
                {
                    responseDto.SetStatusError("No hay registros", StatusCode.NOT_FOUND);
                    return responseDto;
                }
                objDb.ModifiedAt = DateTime.Now;
                objDb.Name = request.Name;
                objDb.Visible = request.Visible.HasValue ? request.Visible.Value : objDb.Visible;
                await _activitiesRepository.SaveChangesAsync();
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

