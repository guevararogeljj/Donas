using System;
using FluentValidation;

namespace Donouts.Application.Activities.Queries.GetById
{
	public class GetByIdValidator : AbstractValidator<GetByIdActivities>
	{
		public GetByIdValidator()
		{
			RuleFor(x => x.Id).NotEmpty().WithMessage("id requerido");
		}
	}
}

