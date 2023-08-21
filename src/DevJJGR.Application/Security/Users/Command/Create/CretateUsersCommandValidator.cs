using System;
using FluentValidation;

namespace Donouts.Application.Security.Users.Command.Create
{
	public class CretateUsersCommandValidator : AbstractValidator<CreateUsersCommand>
	{
		public CretateUsersCommandValidator()
		{
			RuleFor(x => x.Name).NotEmpty();
			RuleFor(x => x.Direction).NotEmpty();
			RuleFor(x => x.Email).NotEmpty();
			RuleFor(x => x.PasswordHash).NotEmpty();
			RuleFor(x => x.PhoneNumber).NotEmpty();
			RuleFor(x => x.UserName).NotEmpty();
		}
    }
}

