using AutoMapper;
using Donouts.Application.Common.Interfaces;
using Donouts.Application.Donnouts.Sales.Queries.GetAll;
using Donouts.Application.Donnouts.Sales.Queries.GetById;
using Donouts.Application.Dto.Donouts;
using Donouts.Domain.Entities.Donouts;
using DonoutsCore.Common.Models;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Donouts.Application.Donnouts.Sales.Queries.GetByPredicate
{
    public class GetByPredicateHandler : IRequestHandler<GetByPredicate, ResponseDto<List<SalesDonoutsDTO>>>
    {
        private readonly ILogger<GetByIdSalesDonoutsHandler> _logger;
        private readonly ISalesDonoutsRepository _salesDonoutsRepository;
        private readonly IMapper _mapper;
        public GetByPredicateHandler(ILogger<GetByIdSalesDonoutsHandler> logger, ISalesDonoutsRepository salesDonoutsRepository, IMapper mapper)
        {
            this._logger = logger;
            this._salesDonoutsRepository = salesDonoutsRepository;
            this._mapper = mapper;
        }
        public async Task<ResponseDto<List<SalesDonoutsDTO>>> Handle(GetByPredicate request, CancellationToken cancellationToken)
        {
            var responseDto = new ResponseDto<List<SalesDonoutsDTO>>();
            try
            {
                Expression<Func<Domain.Entities.Donouts.SalesDonouts, bool>>? predicate = null;
                predicate = x => x.TypeDonouts.Id.Equals(request.TypeDonoutId) 
                && x.Amount > 10;
                var sales = await _salesDonoutsRepository.GetAllByPredicateAsync(predicate);
                if (sales is null)
                {
                    responseDto.SetStatusError("No hay registros", StatusCode.NO_CONTENT);

                    return responseDto;
                }
                var data = _mapper.Map<List<SalesDonoutsDTO>>(sales);
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
