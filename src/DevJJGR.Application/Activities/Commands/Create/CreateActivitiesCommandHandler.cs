using System;
using AutoMapper;
using Donouts.Application.Common.Interfaces;
using Donouts.Application.Donnouts.Sales.Commands.Create;
using DonoutsCore.Common.Models;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Donouts.Application.Activities.Commands.Create
{
	public class CreateActivitiesCommandHandler : IRequestHandler<CreateActivitiesCommand, ResponseDto<Boolean>>
	{
		private readonly ILogger<CreateActivitiesCommandHandler> _logger;
		private readonly IMapper _mapper;
		private readonly IActivitiesRepository _activitiesRepository;
		public CreateActivitiesCommandHandler(ILogger<CreateActivitiesCommandHandler> logger, IMapper mapper, IActivitiesRepository activitiesRepository)
		{
			this._logger = logger;
			this._mapper = mapper;
			this._activitiesRepository = activitiesRepository;
		}

		public async Task<ResponseDto<bool>> Handle(CreateActivitiesCommand request, CancellationToken cancellationToken)
		{
			var responseDto = new ResponseDto<Boolean>();
			try
			{
				var objDb = new Domain.Entities.Activities.Activities();
				objDb.Name = request.Name;
				objDb.Visible = true;
				objDb.CreatedAt = DateTime.Now;
				objDb.ModifiedAt = DateTime.Now;
				objDb.Code = request.Code;
				await this._activitiesRepository.AddAsync(objDb);
				await this._activitiesRepository.SaveChangesAsync();
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

