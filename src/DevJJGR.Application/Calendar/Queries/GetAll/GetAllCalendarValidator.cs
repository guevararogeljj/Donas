using System;
using FluentValidation;

namespace Donouts.Application.Calendar.Queries.GetAll
{
	public class GetAllCalendarValidator : AbstractValidator<GetAllCalendar>
	{
		public GetAllCalendarValidator()
		{
            RuleFor(x => x.PageNumber).NotEmpty().WithMessage("Nùmero de pagina requerido");
            RuleFor(x => x.PageSize).NotEmpty().WithMessage("Tamaño de pagina requerido");
        }
	}
}

