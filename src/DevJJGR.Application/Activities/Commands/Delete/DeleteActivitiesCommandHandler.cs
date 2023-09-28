using AutoMapper;
using Donouts.Application.Common.Interfaces;
using DonoutsCore.Common.Models;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Donouts.Application.Activities.Commands.Delete
{
	public class DeleteCommandActivitiesCommandHandler : IRequestHandler<DeleteActivitiesCommand, ResponseDto<Boolean>>
    {
	    private readonly ILogger<DeleteActivitiesCommand> _logger;
	    private readonly IMapper _mapper;
	    private readonly IActivitiesRepository _activitiesRepository;
		public DeleteCommandActivitiesCommandHandler(ILogger<DeleteActivitiesCommand> logger, IMapper mapper, IActivitiesRepository activitiesRepository)
		{
			this._logger = logger;
			this._mapper = mapper;
            this._activitiesRepository = activitiesRepository;
		}

        public async Task<ResponseDto<bool>> Handle(DeleteActivitiesCommand request, CancellationToken cancellationToken)
        { 
	        var responseDto = new ResponseDto<Boolean>();
	        try
	        {
		        var objDb = await _activitiesRepository.GetById(request.Id);
		        if (objDb is null)
		        {
			        responseDto.SetStatusError("No hay registros", StatusCode.NOT_FOUND);
			        return responseDto;
		        }
		        var data = _mapper.Map<Domain.Entities.Activities.Activities>(objDb);
		        this._activitiesRepository.Delete(data);
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

