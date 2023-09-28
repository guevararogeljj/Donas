

using Donouts.Domain.Entities.Calendario;
using Donouts.Application.Dto.Calendar;
using System.Linq.Expressions;

namespace Donouts.Application.Common.Interfaces
{
	public interface ICalendarRepository : IRepository<CalendarioActividades>
    {
        Task<IEnumerable<CalendarioActividadesDTO>> GetAll(int PageNumber, int PageSize);
        Task<IEnumerable<CalendarioActividadesDTO>> GetAllByPredicateAsync(Expression<Func<CalendarioActividades, bool>> predicate);
        Task<CalendarioActividadesDTO> GetById(Guid id);
    }
}

