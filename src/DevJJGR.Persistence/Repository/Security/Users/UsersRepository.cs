using System.Data.Entity;
using System.Linq.Expressions;
using AutoMapper;
using Donouts.Application.Common.Interfaces;
using Donouts.Application.Dto.Security;
using Donouts.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Donouts.Persistence.Repository.Security.Users
{
	public class UsersRepository : IUsersRepository
	{
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        public UsersRepository(UserManager<ApplicationUser> userManager, IMapper mapper)
		{
            this._userManager = userManager;
            this._mapper = mapper;
		}

        public async Task<IEnumerable<UsersDTO>> GetAll(int PageNumber, int PageSize)
        {
            return  this._mapper.Map<List<UsersDTO>>(this._userManager.Users.ToList());
        }

        public async Task<IEnumerable<UsersDTO>> GetAllByPredicateAsync(Expression<Func<ApplicationUser, bool>> predicate)
        {
            return this._mapper.Map<List<UsersDTO>>(this._userManager.Users.Where(predicate)
             .ToList());
        }

        public async Task<ApplicationUser> GetById(Guid Id)
        {
            return await this._userManager.Users.FirstAsync(x => x.Id.Equals(Id));
        }

        public async Task AddUser(ApplicationUser model)
        {
            await this._userManager.CreateAsync(model);
        }

        public async Task Update(ApplicationUser model)
        {
            await this._userManager.UpdateAsync(model);        }

        public async Task Delete(ApplicationUser model)
        {
             await this._userManager.DeleteAsync(model);
        }
    }
}

