using System.Linq.Expressions;
using Donouts.Application.Dto.Activities;
using Donouts.Domain.Entities.Activities;

namespace Donouts.Application.Common.Interfaces;

public interface IActivitiesRepository: IRepository<Domain.Entities.Activities.Activities>
{
    Task<IEnumerable<ActivitiesDTO>> GetAll(int PageNumber, int PageSize);
    Task<IEnumerable<ActivitiesDTO>> GetAllByPredicateAsync(Expression<Func<Domain.Entities.Activities.Activities, bool>> predicate);
    Task<ActivitiesDTO> GetById(Guid id);
}