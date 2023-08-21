using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donouts.Application.Security.Roles.Queries.GetById
{
    public class GetByIdRoleValidator: AbstractValidator<GetByIdRole>
    {
        public GetByIdRoleValidator() 
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
