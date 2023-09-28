using System;
using Donouts.Application.Common.Interfaces;
using Donouts.Persistence.Common;
using System.Linq.Expressions;
using AutoMapper;
using Donouts.Application.Dto.Activities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Drawing.Printing;

namespace Donouts.Persistance.Repository.Activities
{
	public class ActivitiesRepository : Repository<Domain.Entities.Activities.Activities>, IActivitiesRepository
	{
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public ActivitiesRepository(ApplicationDbContext context, IMapper mapper) : base(context)
        {
            this._context = context;
            this._mapper = mapper;
        }
        public async Task<IEnumerable<ActivitiesDTO>> GetAll(int PageNumber, int PageSize)
        {
            return await this._mapper.ProjectTo<ActivitiesDTO>(this._context.Activities
                  .Skip((PageNumber - 1) * PageSize)
                  .Take(PageSize)
                  .OrderBy(x=> x.CreatedAt)
                  .AsNoTracking())
                  .ToListAsync();
        }

        public async Task<IEnumerable<ActivitiesDTO>> GetAllByPredicateAsync(Expression<Func<Domain.Entities.Activities.Activities, bool>> predicate)
        {
            return await this._mapper.ProjectTo<ActivitiesDTO>(this._context.Activities
                    .Where(predicate)
                    .AsNoTracking())
                    .ToListAsync();
        }

        public async Task<ActivitiesDTO> GetById(Guid Id)
        {
            return await this._mapper.ProjectTo<ActivitiesDTO>(this._context.Activities)
                .FirstOrDefaultAsync(x => x.Id.Equals(Id));
        }
    }
}

