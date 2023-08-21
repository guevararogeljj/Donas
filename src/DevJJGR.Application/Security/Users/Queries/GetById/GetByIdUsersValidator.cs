using System;
using FluentValidation;

namespace Donouts.Application.Security.Users.Queries.GetById
{
	public class GetByIdUsersValidator : AbstractValidator<GetByIdUsers>
	{
		public GetByIdUsersValidator()
		{
			RuleFor(x => x.Id).NotEmpty();
		}
	}
}

