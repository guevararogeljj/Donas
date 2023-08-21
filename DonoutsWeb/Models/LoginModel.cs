using System.ComponentModel.DataAnnotations;

namespace DonoutsWeb.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "usuario es requerido")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Password es requerido")]
        public string? Password { get; set; }
    }
}
