using Donouts.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donouts.Domain.Entities.Donouts
{
    public class SalesDonouts : Entity
    {
        public Guid Id { get; set; }
        public ApplicationUser User { get; set; } = new ApplicationUser();
        public TypeDonouts TypeDonouts { get; set; } = new TypeDonouts();
        public Guid TypeDonoutsId { get; set; }
        public int Amount { get; set; }
        public DateTime SaleDate { get; set; }
    }
}
