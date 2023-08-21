using System;
using FluentValidation;

namespace Donouts.Application.Security.Users.Command.Update
{
	public class UpdateUsersCommandValidator : AbstractValidator<UpdateUsersCommand>
	{
		public UpdateUsersCommandValidator()
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

