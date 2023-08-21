using AutoMapper;
using Donouts.Application.Common.Interfaces;
using Donouts.Application.Dto;
using Donouts.Application.Security.Users.Command.Update;
using DonoutsCore.Common.Models;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donouts.Application.Security.Users.Command.Delete
{
    public class DeleteUsersCommandHandler : IRequestHandler<DeleteUsersCommand, ResponseDto<Boolean>>
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteUsersCommandHandler> _logger;
        public DeleteUsersCommandHandler(IUsersRepository usersRepository, IMapper mapper, ILogger<DeleteUsersCommandHandler> logger)
        {
            this._usersRepository = usersRepository;
            this._mapper = mapper;
            this._logger = logger;
        }

        public async Task<ResponseDto<bool>> Handle(DeleteUsersCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<Boolean>();
            try
            {
                var product = (await this._usersRepository.GetById(request.Id));
                if (product == null)
                    return new ResponseDto<Boolean>("usuario no existente.", StatusCode.BAD_REQUEST);
                
               await this._usersRepository.Delete(product);

                response.Data = true;
                response.SetStatusCode(StatusCode.OK);

                return response;
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, "Error.");
                return new ResponseDto<Boolean>("Surgio un error.", StatusCode.INTERNAL_SERVER_ERROR);
            }
        }
    }
}
