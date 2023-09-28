using System;
using FluentValidation;

namespace Donouts.Application.Activities.Commands.Delete
{
	public class DeleteActivitiesValidator : AbstractValidator<DeleteActivitiesCommand>
	{
		public DeleteActivitiesValidator()
		{
			RuleFor(x => x.Id).NotEmpty().WithMessage("Id requerido");
		}
	}
}

