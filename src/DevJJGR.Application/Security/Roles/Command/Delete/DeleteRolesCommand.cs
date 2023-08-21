using DonoutsCore.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donouts.Application.Security.Roles.Command.Delete
{
    public class DeleteRolesCommand : IRequest<ResponseDto<Boolean>>
    {
        public String Id { get; set; }
    }
}
