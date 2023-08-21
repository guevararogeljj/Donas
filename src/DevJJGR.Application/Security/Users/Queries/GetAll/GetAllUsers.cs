using Donouts.Application.Dto.Security;
using DonoutsCore.Common.Models;
using MediatR;

namespace Donouts.Application.Security.Users.Queries.GetAll
{
	public class GetAllUsers : IRequest<ResponseDto<List<UsersDTO>>>
    {
		public GetAllUsers()
		{
		}
	}
}

