using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donouts.Application.Donnouts.Types.Queries.GetById
{
    public class GetByIdTypeDonoutsValidator: AbstractValidator<GetByIdTypeDonouts>
    {
        public GetByIdTypeDonoutsValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
