


using System.Linq.Expressions;
using AutoMapper;
using Donouts.Application.Common.Interfaces;
using Donouts.Application.Dto.Calendar;
using Donouts.Domain.Entities.Calendario;
using Donouts.Persistence.Common;
using Microsoft.EntityFrameworkCore;

namespace Donouts.Persistance.Repository.Appointment
{
	public class CalendarRepository : Repository<CalendarioActividades>, ICalendarRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public CalendarRepository(ApplicationDbContext context, IMapper mapper) : base(context)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public async Task<IEnumerable<CalendarioActividadesDTO>> GetAll(int PageNumber, int PageSize)
        {
            return await this._mapper.ProjectTo<CalendarioActividadesDTO>(this._context.CalendarioActividades
                .Skip((PageNumber - 1) * PageSize)
                .Take(PageSize)
                .OrderBy(x => x.CreatedAt)
                .AsNoTracking())
                .ToListAsync();
        }

        public async Task<IEnumerable<CalendarioActividadesDTO>> GetAllByPredicateAsync(Expression<Func<CalendarioActividades, bool>> predicate)
        {
            return await this._mapper.ProjectTo<CalendarioActividadesDTO>(this._context.CalendarioActividades
              .Where(predicate)
              .Include(x=> x.UserCreated)
              .Include(x=> x.UserModified)
              .AsNoTracking())
              .ToListAsync();
        }

        public async Task<CalendarioActividadesDTO> GetById(Guid Id)
        {
            return await this._mapper.ProjectTo<CalendarioActividadesDTO>(this._context.CalendarioActividades)
            .FirstOrDefaultAsync(x => x.Id.Equals(Id));
        }
    }
}

