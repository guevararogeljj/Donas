using System;
using AutoMapper;
using Donouts.Application.Common.Interfaces;
using Donouts.Application.Donnouts.Sales.Queries.GetById;
using Donouts.Application.Dto.Activities;
using Donouts.Application.Dto.Donouts;
using DonoutsCore.Common.Models;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Donouts.Application.Activities.Queries.GetById
{
    public class GetByIdActivitiesHandler : IRequestHandler<GetByIdActivities, ResponseDto<ActivitiesDTO>>
    {
        private readonly ILogger<GetByIdActivitiesHandler> _logger;
        private readonly IActivitiesRepository _activitiesRepository;
        private readonly IMapper _mapper;
        public GetByIdActivitiesHandler(ILogger<GetByIdActivitiesHandler> logger, IActivitiesRepository activitiesRepository, IMapper mapper)
        {
            this._logger = logger;
            this._activitiesRepository = activitiesRepository;
            this._mapper = mapper;
        }
        public async Task<ResponseDto<ActivitiesDTO>> Handle(GetByIdActivities request, CancellationToken cancellationToken)
        {
            var responseDto = new ResponseDto<ActivitiesDTO>();
            try
            {
                var sales = await _activitiesRepository.GetById(request.Id);
                if (sales is null)
                {
                    responseDto.SetStatusError("No hay registros", StatusCode.NO_CONTENT);

                    return responseDto;
                }
                var data = _mapper.Map<ActivitiesDTO>(sales);
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

