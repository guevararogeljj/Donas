using DonoutsCore.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donouts.Application.Donnouts.Types.Commands.Update
{
    public class UpdateTypeDonoutsCommand : IRequest<ResponseDto<Boolean>>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
