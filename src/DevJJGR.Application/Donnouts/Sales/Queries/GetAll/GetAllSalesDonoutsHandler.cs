using AutoMapper;
using Donouts.Application.Common.Interfaces;
using Donouts.Application.Donnouts.Types.Queries.GetAll;
using Donouts.Application.Donnouts.Types.Queries.GetById;
using Donouts.Application.Dto.Donouts;
using DonoutsCore.Common.Models;
using MediatR;
using Microsoft.Extensions.Logging;


namespace Donouts.Application.Donnouts.Sales.Queries.GetAll
{
    public class GetAllSalesDonoutsHandler : IRequestHandler<GetAllSalesDonouts, ResponseDto<List<SalesDonoutsDTO>>>
    {
        private readonly ILogger<GetAllSalesDonoutsHandler> _logger;
        private readonly ISalesDonoutsRepository _salesDonoutsRepository;
        private readonly IMapper _mapper;
        public GetAllSalesDonoutsHandler(ILogger<GetAllSalesDonoutsHandler> logger, ISalesDonoutsRepository salesDonoutsRepository,
            IMapper mapper)
        {
            this._logger = logger;
            this._salesDonoutsRepository = salesDonoutsRepository;
            this._mapper = mapper;
        }
        public async Task<ResponseDto<List<SalesDonoutsDTO>>> Handle(GetAllSalesDonouts request, CancellationToken cancellationToken)
        {
            var responseDto = new ResponseDto<List<SalesDonoutsDTO>>();
            try
            {
                var sales = await _salesDonoutsRepository.GetAll();
                if (sales.Count() <= 0)
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
