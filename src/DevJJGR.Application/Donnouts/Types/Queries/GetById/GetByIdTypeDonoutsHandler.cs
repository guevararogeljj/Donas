using AutoMapper;
using Donouts.Application.Common.Interfaces;
using Donouts.Application.Donnouts.Types.Queries.GetAll;
using Donouts.Application.Dto.Donouts;
using DonoutsCore.Common.Models;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donouts.Application.Donnouts.Types.Queries.GetById
{
    public class GetByIdTypeDonoutsHandler : IRequestHandler<GetByIdTypeDonouts, ResponseDto<TypeDonoutsDTO>>
    {
        private readonly ILogger<GetByIdTypeDonoutsHandler> _logger;
        private readonly ITypeDonoutsRepository _typeDonoutsRepository;
        private readonly IMapper _mapper;
        public GetByIdTypeDonoutsHandler(ILogger<GetByIdTypeDonoutsHandler> logger,
            ITypeDonoutsRepository typeDonoutsRepository, IMapper mapper)
        {
            this._logger = logger;
            this._typeDonoutsRepository = typeDonoutsRepository;
            this._mapper = mapper;
        }
        public async Task<ResponseDto<TypeDonoutsDTO>> Handle(GetByIdTypeDonouts request, CancellationToken cancellationToken)
        {
            var responseDto = new ResponseDto<TypeDonoutsDTO>();
            try
            {
                var donouts = await _typeDonoutsRepository.GetById(request.Id);
                if (donouts is null)
                {
                    responseDto.SetStatusError("No hay registros", StatusCode.NO_CONTENT);

                    return responseDto;
                }
                var data = _mapper.Map<TypeDonoutsDTO>(donouts);
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
