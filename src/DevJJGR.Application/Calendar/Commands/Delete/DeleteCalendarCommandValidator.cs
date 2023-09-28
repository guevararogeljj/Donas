using System;
using FluentValidation;

namespace Donouts.Application.Calendar.Commands.Delete
{
	public class DeleteCalendarCommandValidator : AbstractValidator<DeleteCalendarCommand>
	{
		public DeleteCalendarCommandValidator()
		{
			RuleFor(x => x.Id).NotEmpty().WithMessage("Id requerido");
		}
	}
}

