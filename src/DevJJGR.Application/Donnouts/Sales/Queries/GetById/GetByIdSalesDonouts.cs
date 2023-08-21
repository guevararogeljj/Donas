using Donouts.Application.Dto.Donouts;
using DonoutsCore.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donouts.Application.Donnouts.Sales.Queries.GetById
{
    public class GetByIdSalesDonouts : IRequest<ResponseDto<SalesDonoutsDTO>>
    {
        public Guid Id { get; set; }
    }
}
