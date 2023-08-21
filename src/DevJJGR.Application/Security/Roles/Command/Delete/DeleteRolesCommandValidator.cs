using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donouts.Application.Security.Roles.Command.Delete
{
    public class DeleteRolesCommandValidator: AbstractValidator<DeleteRolesCommand>
    {
        public DeleteRolesCommandValidator() 
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
