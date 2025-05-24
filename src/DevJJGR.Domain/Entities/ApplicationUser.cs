
using Donouts.Domain.Entities.Donouts;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Donouts.Domain.Entities
{
    public class ApplicationUser : IdentityUser<Guid>
    {

        [Required(ErrorMessage = "Nombre obligatorio")]
        [Column(TypeName = "varchar(250)")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Dirección obligatoria")]
        [Column(TypeName = "varchar(300)")]
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public string Direction { get; set; } = string.Empty;
    } 
}
