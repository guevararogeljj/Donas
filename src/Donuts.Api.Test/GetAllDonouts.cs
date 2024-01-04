using Donouts.Application.Common.Interfaces;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Donouts.Application.Dto.Donouts;
using System.Linq.Expressions;
using Donouts.Domain.Entities.Donouts;

namespace Donuts.Api.Test;

public class GetAllDonouts
{

    public class GetAllApi : WebApplicationFactory<Program>
    {
        protected override IHost CreateHost(IHostBuilder builder)
        {
            builder.ConfigureServices(x => 
                x.AddScoped<ISalesDonoutsRepository>(_ => new FakeintegrationPublisher()));
            return base.CreateHost(builder);
        }
    }
    public class FakeintegrationPublisher : ISalesDonoutsRepository
    {
        public async Task<IEnumerable<SalesDonoutsDTO>> GetAll()
        {
            return new List<SalesDonoutsDTO>();
        }

        public async Task<IEnumerable<SalesDonoutsDTO>> GetAllByPredicateAsync(Expression<Func<Donouts.Domain.Entities.Donouts.SalesDonouts, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<Donouts.Domain.Entities.Donouts.SalesDonouts> GetById(Guid Id)
        {
            throw new NotImplementedException();
        }

        Task IRepository<SalesDonouts>.AddAsync(SalesDonouts item)
        {
            throw new NotImplementedException();
        }

        Task IRepository<SalesDonouts>.AddRangeAsync(List<SalesDonouts> range)
        {
            throw new NotImplementedException();
        }

        Task<bool> IRepository<SalesDonouts>.AnyAsync(Expression<Func<SalesDonouts, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        Task<int> IRepository<SalesDonouts>.CountAsync()
        {
            throw new NotImplementedException();
        }

        Task<int> IRepository<SalesDonouts>.CountAsync(Expression<Func<SalesDonouts, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        Task<int> IRepository<SalesDonouts>.CountAsync(ISpecification<SalesDonouts> specification)
        {
            throw new NotImplementedException();
        }

        void IRepository<SalesDonouts>.Delete(SalesDonouts item)
        {
            throw new NotImplementedException();
        }

        void IRepository<SalesDonouts>.DeleteRange(IEnumerable<SalesDonouts> items)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<SalesDonouts>> IRepository<SalesDonouts>.FilterAsync(Expression<Func<SalesDonouts, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<SalesDonouts>> IRepository<SalesDonouts>.FilterAsync(ISpecification<SalesDonouts> specification)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<SalesDonouts>> IRepository<SalesDonouts>.FilterTrackingAsync(Expression<Func<SalesDonouts, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        Task<SalesDonouts> IRepository<SalesDonouts>.FirstOrDefaultAsync(Expression<Func<SalesDonouts, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        Task<SalesDonouts> IRepository<SalesDonouts>.FirstOrDefaultTrackingAsync(Expression<Func<SalesDonouts, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<SalesDonouts>> IRepository<SalesDonouts>.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<SalesDonouts>> IRepository<SalesDonouts>.GetAllTrackingAsync()
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<SalesDonouts>> IRepository<SalesDonouts>.PaginationAscAsync(Expression<Func<SalesDonouts, bool>> predicate, Expression<Func<SalesDonouts, object>> orderBy, int page, int sizePage)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<SalesDonouts>> IRepository<SalesDonouts>.PaginationDescAsync(Expression<Func<SalesDonouts, bool>> predicate, Expression<Func<SalesDonouts, object>> orderBy, int page, int sizePage)
        {
            throw new NotImplementedException();
        }

        void IRepository<SalesDonouts>.Remove(SalesDonouts item)
        {
            throw new NotImplementedException();
        }

        void IRepository<SalesDonouts>.RemoveRange(IEnumerable<SalesDonouts> items)
        {
            throw new NotImplementedException();
        }

        Task IRepository<SalesDonouts>.SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        Task IRepository<SalesDonouts>.SaveChangesAsync(SalesDonouts entity)
        {
            throw new NotImplementedException();
        }

        void IRepository<SalesDonouts>.Update(SalesDonouts item)
        {
            throw new NotImplementedException();
        }

        void IRepository<SalesDonouts>.UpdateRange(IEnumerable<SalesDonouts> items)
        {
            throw new NotImplementedException();
        }
    }
}

