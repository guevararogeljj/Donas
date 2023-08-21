using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donouts.Application.Donnouts.Types.Commands.Update
{
    public class UpdateTypeDonoutsCommandValidator : AbstractValidator<UpdateTypeDonoutsCommand>

    {
        public UpdateTypeDonoutsCommandValidator()
        {
            RuleFor(v => v.Id)
                .NotEmpty().WithMessage("Id es requerido.");
            RuleFor(v => v.Name)
                .NotEmpty().WithMessage("Name es requerido.");
        }
    }

} 
