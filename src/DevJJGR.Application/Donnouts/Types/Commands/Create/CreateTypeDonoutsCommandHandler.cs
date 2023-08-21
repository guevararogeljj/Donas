using AutoMapper;
using Donouts.Application.Common.Interfaces;
using Donouts.Domain.Entities.Donouts;
using DonoutsCore.Common.Models;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donouts.Application.Donnouts.Types.Commands.Create
{
    public class CreateTypeDonoutsCommandHandler : IRequestHandler<CreateTypeDonoutsCommand, ResponseDto<Boolean>>
    {
        private readonly ILogger<CreateTypeDonoutsCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly ITypeDonoutsRepository _typeDonoutsRepository;
        public CreateTypeDonoutsCommandHandler(ILogger<CreateTypeDonoutsCommandHandler> logger, IMapper mapper, ITypeDonoutsRepository typeDonoutsRepository)
        {
            this._logger = logger;
            this._mapper = mapper;
            this._typeDonoutsRepository = typeDonoutsRepository;
        }
        public async Task<ResponseDto<bool>> Handle(CreateTypeDonoutsCommand request, CancellationToken cancellationToken)
        {
            var responseDto = new ResponseDto<Boolean>();
            try
            {
                var objDb = new TypeDonouts();
                objDb.Name = request.Name;
                objDb.Visible = true;
                objDb.CreatedAt = DateTime.Now;
                objDb.ModifiedAt = DateTime.Now;
                await _typeDonoutsRepository.AddAsync(objDb);
                await _typeDonoutsRepository.SaveChangesAsync();
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
