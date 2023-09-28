using System;
using FluentValidation;

namespace Donouts.Application.Activities.Commands.Create
{
	public class CreateActivitiesCommandValidator : AbstractValidator<CreateActivitiesCommand>
	{
		public CreateActivitiesCommandValidator()
		{
			RuleFor(x => x.Name).NotEmpty().WithMessage("nombre requerido");
			RuleFor(x => x.Code).NotEmpty().WithMessage("código requerido");
		}
	}
}

