using System.ComponentModel.DataAnnotations.Schema;

namespace Donouts.Domain.Common
{
    public abstract class Entity
    {
        public bool Visible { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string Code { get; set; } = string.Empty;
        [Column(TypeName = "varchar(250)")]
        public string Name { get; set; } = string.Empty;

        public void SoftRemove()
        {
            this.Visible = true;

        }
    }
}
