using System;
using Donouts.Application.Dto.Security;
using DonoutsCore.Common.Models;
using MediatR;

namespace Donouts.Application.Security.Users.Queries.GetById
{
	public class GetByIdUsers : IRequest<ResponseDto<UsersDTO>>
	{
		public Guid Id { get; set; }
        public GetByIdUsers()
        {
            
        }

    }
}

