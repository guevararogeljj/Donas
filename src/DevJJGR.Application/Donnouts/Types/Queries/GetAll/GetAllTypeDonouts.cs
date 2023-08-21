﻿using Donouts.Application.Dto.Donouts;
using DonoutsCore.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donouts.Application.Donnouts.Types.Queries.GetAll
{
    public class GetAllTypeDonouts: IRequest<ResponseDto<List<TypeDonoutsDTO>>>
    {
        public GetAllTypeDonouts()
        {
            
        }
    }
}
