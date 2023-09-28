using System;
using FluentValidation;

namespace Donouts.Application.Calendar.Queries.GetById
{
	public class GetByIdCalendarValidator : AbstractValidator<GetByIdCalendar>
	{
		public GetByIdCalendarValidator()
		{
			RuleFor(x => x.Id).NotEmpty().WithMessage("Id requerido");
		}
	}
}

