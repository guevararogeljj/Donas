using Donouts.Application.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donouts.Application.Common.Interfaces
{
    public interface IAuthService
    {
        Task<(int, string)> Login(LoginModel model);
    }
}
