using System;
using Donouts.Application.Dto;
using System.Linq.Expressions;
using Donouts.Application.Dto.Security;
using Donouts.Domain.Entities;

namespace Donouts.Application.Common.Interfaces
{
	public interface IUsersRepository
    {
        Task<IEnumerable<UsersDTO>> GetAll();
        Task<IEnumerable<UsersDTO>> GetAllByPredicateAsync(Expression<Func<Donouts.Domain.Entities.ApplicationUser, bool>> predicate);
        Task<ApplicationUser> GetById(Guid Id);
        Task AddUser(ApplicationUser model);
        Task Update(ApplicationUser model);
        Task Delete(ApplicationUser model);
    }
}

