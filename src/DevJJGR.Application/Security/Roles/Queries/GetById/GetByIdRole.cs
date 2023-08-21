using Donouts.Application.Dto.Security;
using DonoutsCore.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donouts.Application.Security.Roles.Queries.GetById
{
    public class GetByIdRole : IRequest<ResponseDto<RoleDTO>>
    {
        public string Id { get; set; } = string.Empty;

    }
}
