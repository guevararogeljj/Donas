using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donouts.Application.utils
{
    public class LoginModel
    {
        [Required(ErrorMessage = "usuario es requerido")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Password es requerido")]
        public string? Password { get; set; }
    }
}
