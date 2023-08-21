using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donouts.Application.Donnouts.Sales.Commands.Create
{
    public class CreateSalesDonoutsValidator : AbstractValidator<CreateSalesDonoutsCommand>
    {
        public CreateSalesDonoutsValidator()
        {
            RuleFor(x => x.TypeDonoutsId).NotEmpty().WithMessage("El campo TypeDonoutsId es requerido");
            RuleFor(x => x.Amount).NotEmpty().WithMessage("El campo Amount es requerido");
        }
    }
}
