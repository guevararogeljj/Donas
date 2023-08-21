using AutoMapper;
using Donouts.Application.Common.Interfaces;
using Donouts.Domain.Entities;
using Donouts.Domain.Entities.Donouts;
using DonoutsCore.Common.Models;
using MediatR;
using Microsoft.Extensions.Logging;


namespace Donouts.Application.Donnouts.Sales.Commands.Create
{
    public class CreateSalesDonoutsCommandHandler : IRequestHandler<CreateSalesDonoutsCommand, ResponseDto<Boolean>>
    {
        private readonly ILogger<CreateSalesDonoutsCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly ISalesDonoutsRepository _salesDonoutsRepository;
        private readonly ICurrentUserService _currentUserService;
        private readonly ITypeDonoutsRepository _typeDonoutsRepository;
        private readonly Microsoft.AspNetCore.Identity.UserManager<ApplicationUser> _userManager;
        public CreateSalesDonoutsCommandHandler(ILogger<CreateSalesDonoutsCommandHandler> logger, IMapper mapper, 
            ISalesDonoutsRepository salesDonoutsRepository, ICurrentUserService currentUserService,
            Microsoft.AspNetCore.Identity.UserManager<ApplicationUser>  userManager, ITypeDonoutsRepository typeDonoutsRepository)
        {
            this._logger = logger;
            this._mapper = mapper;
            this._salesDonoutsRepository = salesDonoutsRepository;
            this._currentUserService = currentUserService;
            this._userManager = userManager;
            this._typeDonoutsRepository = typeDonoutsRepository;
        }
        public async Task<ResponseDto<bool>> Handle(CreateSalesDonoutsCommand request, CancellationToken cancellationToken)
        {
            var responseDto = new ResponseDto<Boolean>();
            try
            {
                var objDb = new SalesDonouts();
                var userName = this._currentUserService.UserName;
                var user = await _userManager.FindByNameAsync(userName!);
                var typeDonouts = await _typeDonoutsRepository.GetById(request.TypeDonoutsId);
                objDb.Name = "";
                objDb.Visible = true;
                objDb.CreatedAt = DateTime.Now;
                objDb.ModifiedAt = DateTime.Now;
                objDb.SaleDate = DateTime.Now;
                objDb.TypeDonouts = typeDonouts!;
                objDb.Amount = request.Amount;
                objDb.User = user!;
                await _salesDonoutsRepository.AddAsync(objDb);
                await _salesDonoutsRepository.SaveChangesAsync();
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
