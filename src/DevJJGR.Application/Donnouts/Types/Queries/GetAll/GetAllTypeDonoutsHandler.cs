using AutoMapper;
using Donouts.Application.Common.Interfaces;
using Donouts.Application.Dto.Donouts;
using DonoutsCore.Common.Models;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donouts.Application.Donnouts.Types.Queries.GetAll
{
    public class GetAllTypeDonoutsHandler : IRequestHandler<GetAllTypeDonouts, ResponseDto<List<TypeDonoutsDTO>>>
    {
        private readonly ILogger<GetAllTypeDonoutsHandler> _logger;
        private readonly ITypeDonoutsRepository _typeDonoutsRepository;
        private readonly IMapper _mapper;
        public GetAllTypeDonoutsHandler(ILogger<GetAllTypeDonoutsHandler> logger, 
            ITypeDonoutsRepository typeDonoutsRepository, IMapper mapper)
        {
            this._logger = logger;
            this._typeDonoutsRepository = typeDonoutsRepository;
            this._mapper = mapper;
        }
        public async Task<ResponseDto<List<TypeDonoutsDTO>>> Handle(GetAllTypeDonouts request, CancellationToken cancellationToken)
        {
            var responseDto = new ResponseDto<List<TypeDonoutsDTO>>();
            try
            {
                var donouts = await _typeDonoutsRepository.GetAll();
                if (donouts.Count() <= 0)
                {
                    responseDto.SetStatusError("No hay registros", StatusCode.NO_CONTENT);

                    return responseDto;
                }
                var data = _mapper.Map<List<TypeDonoutsDTO>>(donouts);
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
