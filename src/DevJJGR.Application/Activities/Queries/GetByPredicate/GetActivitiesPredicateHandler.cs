
using System.Linq.Expressions;
using AutoMapper;
using Donouts.Application.Common.Interfaces;
using Donouts.Application.Dto.Activities;
using DonoutsCore.Common.Models;
using LinqKit;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Donouts.Application.Activities.Queries.GetByPredicate
{
    public class GetActivitiesPredicateHandler : IRequestHandler<GetByActivitiesPredicate, ResponseDto<List<ActivitiesDTO>>>
    {
        private readonly ILogger<GetActivitiesPredicateHandler> _logger;
        private readonly IActivitiesRepository _activitiesRepository;
        private readonly IMapper _mapper;
        public GetActivitiesPredicateHandler(ILogger<GetActivitiesPredicateHandler> logger, IActivitiesRepository activitiesRepository, IMapper mapper)
        {
            this._logger = logger;
            this._activitiesRepository = activitiesRepository;
            this._mapper = mapper;
        }

        public async Task<ResponseDto<List<ActivitiesDTO>>> Handle(GetByActivitiesPredicate request, CancellationToken cancellationToken)
        {
            var responseDto = new ResponseDto<List<ActivitiesDTO>>();
            try
            {

                Expression<Func<Domain.Entities.Activities.Activities, bool>>? predicate = null;
                if (request.HasFilter())
                {
                    predicate = this.GetFilter(request);
                }
                var activities = await this._activitiesRepository.GetAllByPredicateAsync(predicate!);
                if (activities is null)
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

        private ExpressionStarter<Domain.Entities.Activities.Activities> GetFilter(GetByActivitiesPredicate query)
        {
            var predicate = PredicateBuilder.New<Domain.Entities.Activities.Activities>(true);
            if (query.Id.HasValue)
            {
                predicate.And(x => x.Id.Equals(query.Id));
            }
            if(!string.IsNullOrEmpty(query.Name?.Trim()))
            {
                predicate.And(x => x.Name.ToUpper().Contains(query.Name.Trim().ToUpper()));
            }
            return predicate;
        }
    }
}

