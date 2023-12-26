using Donouts.Application.Dto.Security;
using DonoutsCore.Common.Models;
using MediatR;

namespace Donouts.Application.Security.Users.Queries.GetAll
{
	public class GetAllUsers : IRequest<ResponseDto<List<UsersDTO>>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public GetAllUsers(int pageNumber, int pageSize)
        {
            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
        }
        public GetAllUsers()
		{
		}
	}
}

