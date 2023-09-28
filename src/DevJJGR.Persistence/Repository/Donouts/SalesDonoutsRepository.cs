using AutoMapper;
using Donouts.Application.Common.Interfaces;
using Donouts.Application.Dto.Donouts;
using Microsoft.EntityFrameworkCore;
using Donouts.Domain.Entities.Donouts;
using Donouts.Persistence.Common;
using System.Linq.Expressions;


namespace Donouts.Persistance.Repository.Donouts
{
    public class SalesDonoutsRepository : Repository<Domain.Entities.Donouts.SalesDonouts>, ISalesDonoutsRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public SalesDonoutsRepository(ApplicationDbContext dbContext,
                       ApplicationDbContext context, IMapper mapper) : base(dbContext)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public async Task<IEnumerable<SalesDonoutsDTO>> GetAll()
        {
            return await this._mapper.ProjectTo<SalesDonoutsDTO>(this._context.SalesDonouts
               .Include(x=>x.TypeDonouts)
               .AsNoTracking())
               .ToListAsync();
        }

        public async Task<IEnumerable<SalesDonoutsDTO>> GetAllByPredicateAsync(Expression<Func<Domain.Entities.Donouts.SalesDonouts, bool>> predicate)
        {
            return await this._mapper.ProjectTo<SalesDonoutsDTO>(this._context.SalesDonouts
                  .Where(predicate)
                  .Include(x => x.TypeDonouts)
                  .AsNoTracking())
                  .ToListAsync();
        }

        public async Task<Domain.Entities.Donouts.SalesDonouts> GetById(Guid Id)
        {
            return await this._context.SalesDonouts
                .Include(x => x.TypeDonouts)
                .FirstOrDefaultAsync(x => x.Id.Equals(Id));
        }
    }
}
