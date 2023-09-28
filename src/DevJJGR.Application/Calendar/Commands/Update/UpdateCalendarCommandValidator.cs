using System;
using FluentValidation;

namespace Donouts.Application.Calendar.Commands.Update
{
	public class UpdateCalendarCommandValidator : AbstractValidator<UpdateCalendarCommand>
	{
		public UpdateCalendarCommandValidator()
		{
			RuleFor(x => x.ActivityId).NotEmpty().WithMessage("Actividad requerida");
            RuleFor(x => x.EventDate).NotEmpty().WithMessage("fecha inicio requerido");
            RuleFor(x => x.StartTime).NotEmpty().WithMessage("Hora inicio requerido");
            RuleFor(x => x.EndTime).NotEmpty().WithMessage("Hora fin requerido");
            RuleFor(x => x.ClosedDate).NotEmpty().WithMessage("fecha fin requerido");
        }
	}
}

