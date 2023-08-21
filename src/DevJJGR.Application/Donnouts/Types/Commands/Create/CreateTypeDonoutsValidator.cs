using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donouts.Application.Donnouts.Types.Commands.Create
{
    public class CreateTypeDonoutsValidator: AbstractValidator<CreateTypeDonoutsCommand>
    {
        public CreateTypeDonoutsValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("El nombre no puede estar vacio");
        }
    }
}
