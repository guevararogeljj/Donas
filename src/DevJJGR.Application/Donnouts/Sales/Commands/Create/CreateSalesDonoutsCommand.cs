using Donouts.Application.Dto.Donouts;
using Donouts.Application.Dto.Security;
using DonoutsCore.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donouts.Application.Donnouts.Sales.Commands.Create
{
    public class CreateSalesDonoutsCommand : IRequest<ResponseDto<Boolean>>
    {
        public Guid TypeDonoutsId { get; set; }
        public int Amount { get; set; }
    }
}
