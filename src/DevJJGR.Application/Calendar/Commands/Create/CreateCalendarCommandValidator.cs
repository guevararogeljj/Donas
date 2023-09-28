using System;
using FluentValidation;

namespace Donouts.Application.Calendar.Commands.Create
{
	public class CreateCalendarCommandValidator : AbstractValidator<CreateCalendarCommand>
	{
		public CreateCalendarCommandValidator()
		{
			RuleFor(x => x.ActivityId).NotEmpty().WithMessage("La actividad es requerida");
            RuleFor(x => x.EventDate).NotEmpty().WithMessage("Fecha de evento requerida");
            RuleFor(x => x.StartTime).NotEmpty().WithMessage("Hora inicio de evento requerida");
            RuleFor(x => x.EndTime).NotEmpty().WithMessage("Hora fin de evento requerida");
            RuleFor(x => x.ClosedDate).NotEmpty().WithMessage("Fecha fin requerido");
            RuleFor(x => x.Comments).NotEmpty().WithMessage("Comentarios requeridos");            
        }
	}
}

