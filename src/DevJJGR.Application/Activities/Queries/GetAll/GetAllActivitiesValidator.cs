using System;
using FluentValidation;

namespace Donouts.Application.Activities.Queries.GetAll
{
	public class GetAllActivitiesValidator : AbstractValidator<GetAllActivities>
	{
		public GetAllActivitiesValidator()
		{
			RuleFor(x => x.PageNumber).NotEmpty().WithMessage("Nùmero de pagina requerido");
			RuleFor(x => x.PageSize).NotEmpty().WithMessage("Tamaño de pagina requerido");
		}
	}
}

