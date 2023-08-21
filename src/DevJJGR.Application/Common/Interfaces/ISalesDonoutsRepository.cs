﻿using Donouts.Application.Dto.Donouts;
using Donouts.Domain.Entities.Donouts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Donouts.Application.Common.Interfaces
{
    public interface ISalesDonoutsRepository : IRepository<SalesDonouts>
    {
        Task<IEnumerable<SalesDonoutsDTO>> GetAll();
        Task<IEnumerable<SalesDonoutsDTO>> GetAllByPredicateAsync(Expression<Func<Donouts.Domain.Entities.Donouts.SalesDonouts, bool>> predicate);
        Task<SalesDonouts> GetById(Guid Id);
    }
}
