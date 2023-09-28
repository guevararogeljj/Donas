using AutoMapper;
using Donouts.Application.Common.Interfaces;
using Donouts.Application.Donnouts.Sales.Queries.GetAll;
using Donouts.Application.Dto.Activities;
using DonoutsCore.Common.Models;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Donouts.Application.Activities.Queries.GetAll;

public class GetAllActivitiesHandler: IRequestHandler<GetAllActivities, ResponseDto<List<ActivitiesDTO>>>
{
    private readonly ILogger<GetAllActivitiesHandler> _logger;
    private readonly IActivitiesRepository _activitiesRepository;
    private readonly IMapper _mapper;

    public GetAllActivitiesHandler(ILogger<GetAllActivitiesHandler> logger, 
        IActivitiesRepository activitiesRepository, IMapper mapper)
    {
        this._logger = logger;
        this._activitiesRepository = activitiesRepository;
        this._mapper = mapper;
    }
    public async Task<ResponseDto<List<ActivitiesDTO>>> Handle(GetAllActivities request, CancellationToken cancellationToken)
    {
        var responseDto = new ResponseDto<List<ActivitiesDTO>>();
        try
        {
            var activities = await _activitiesRepository.GetAll(request.PageNumber, request.PageSize);
            if (activities.Count() <= 0)
            {
                responseDto.SetStatusError("No hay registros", StatusCode.NO_CONTENT);
                return responseDto;
            }
            var data = _mapper.Map<List<ActivitiesDTO>>(activities);
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