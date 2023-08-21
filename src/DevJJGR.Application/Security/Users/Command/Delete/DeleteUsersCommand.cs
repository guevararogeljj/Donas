using DonoutsCore.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donouts.Application.Security.Users.Command.Delete
{
    public class DeleteUsersCommand: IRequest<ResponseDto<Boolean>>
    {
        public Guid Id { get; set; }
    }
}
