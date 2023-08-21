using AutoMapper;
using Donouts.Application.Common.Interfaces;
using Donouts.Application.Donnouts.Types.Commands.Create;
using DonoutsCore.Common.Models;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donouts.Application.Donnouts.Types.Commands.Update
{
    public class UpdateTypeDonoutsCommandHandler : IRequestHandler<UpdateTypeDonoutsCommand, ResponseDto<Boolean>>
    {
        private readonly ILogger<UpdateTypeDonoutsCommandHandler> _logger;
        private readonly ITypeDonoutsRepository _typeDonoutsRepository;
        public UpdateTypeDonoutsCommandHandler(ILogger<UpdateTypeDonoutsCommandHandler> logger, ITypeDonoutsRepository typeDonoutsRepository)
        {
            this._typeDonoutsRepository = typeDonoutsRepository;
            this._logger = logger;
        }
        public async Task<ResponseDto<bool>> Handle(UpdateTypeDonoutsCommand request, CancellationToken cancellationToken)
        {

            var responseDto = new ResponseDto<Boolean>();
            try
            {
                var objDb = await _typeDonoutsRepository.GetById(request.Id);
                if (objDb is null)
                {
                    responseDto.SetStatusError("No hay registros", StatusCode.NOT_FOUND);
                    return responseDto;
                }
                objDb.ModifiedAt = DateTime.Now;
                objDb.Name = request.Name;
                await _typeDonoutsRepository.SaveChangesAsync();
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
