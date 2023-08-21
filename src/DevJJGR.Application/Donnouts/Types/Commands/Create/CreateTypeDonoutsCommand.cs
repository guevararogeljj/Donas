using DonoutsCore.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donouts.Application.Donnouts.Types.Commands.Create
{
    public class CreateTypeDonoutsCommand : IRequest<ResponseDto<Boolean>>
    {
        public string Name { get; set; } = string.Empty;
    }
}
