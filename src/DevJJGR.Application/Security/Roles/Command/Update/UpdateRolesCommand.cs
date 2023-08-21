using DonoutsCore.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donouts.Application.Security.Roles.Command.Update
{
    public class UpdateRolesCommand : IRequest<ResponseDto<Boolean>>
    {
        public String Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
    }
}
