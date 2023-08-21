using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donouts.Application.Donnouts.Types.Commands.Delete
{
    public class DeleteTypeDonoutsValidator : AbstractValidator<DeleteTypeDonoutsCommand>
    {
        public DeleteTypeDonoutsValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("El campo Id es requerido");
        }
    }
}
