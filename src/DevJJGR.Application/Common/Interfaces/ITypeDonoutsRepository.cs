using Donouts.Application.Dto.Donouts;
using Donouts.Application.Dto.Security;
using Donouts.Domain.Entities;
using Donouts.Domain.Entities.Donouts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Donouts.Application.Common.Interfaces
{
    public interface ITypeDonoutsRepository : IRepository<TypeDonouts>
    {
        Task<IEnumerable<TypeDonoutsDTO>> GetAll();
        Task<IEnumerable<TypeDonoutsDTO>> GetAllByPredicateAsync(Expression<Func<Donouts.Domain.Entities.Donouts.TypeDonouts, bool>> predicate);
        Task<TypeDonouts> GetById(Guid Id);

    }
}
