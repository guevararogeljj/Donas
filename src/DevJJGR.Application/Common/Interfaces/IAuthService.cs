using Donouts.Application.Dto.Security;
using Donouts.Application.utils;
using DonoutsCore.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donouts.Application.Common.Interfaces
{
    public interface IAuthService
    {
        Task<ResponseDto<TokenResponseDTO>> Login(LoginModel model);
    }
}
