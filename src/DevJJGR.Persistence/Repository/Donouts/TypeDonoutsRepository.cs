using AutoMapper;
using Donouts.Application.Common.Interfaces;
using Donouts.Application.Dto.Donouts;
using Microsoft.EntityFrameworkCore;
using Donouts.Domain.Entities.Donouts;
using Donouts.Persistence.Common;
using System.Linq.Expressions;


namespace Donouts.Persistance.Repository.Donouts
{
    public class TypeDonoutsRepository : Repository<TypeDonouts>, ITypeDonoutsRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public TypeDonoutsRepository(ApplicationDbContext dbContext,
            ApplicationDbContext context, IMapper mapper) : base(dbContext)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public async Task<IEnumerable<TypeDonoutsDTO>> GetAll()
        {
            return await this._mapper.ProjectTo<TypeDonoutsDTO>(this._context.TypeDonouts
                .AsNoTracking())
                .ToListAsync();
        }

        public async Task<IEnumerable<TypeDonoutsDTO>> GetAllByPredicateAsync(Expression<Func<TypeDonouts, bool>> predicate)
        {
            return await this._mapper.ProjectTo<TypeDonoutsDTO>(this._context.TypeDonouts
                       .Where(predicate))
                       .AsNoTracking()
                       .ToListAsync();
        }

        public async Task<TypeDonouts> GetById(Guid Id)
        {
            return await this._context.TypeDonouts.FirstAsync(x => x.Id.Equals(Id));
        }

    }
}
