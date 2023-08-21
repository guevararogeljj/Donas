using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donouts.Application.Donnouts.Sales.Queries.GetById
{
    public class GetByIdSalesDonoutsValidator: AbstractValidator<GetByIdSalesDonouts>
    {
        public GetByIdSalesDonoutsValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("El Id es requerido");
        }
    }
}
