using Donouts.Application.Dto.Security;
using Donouts.Domain.Entities;
using Donouts.Domain.Entities.Donouts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donouts.Application.Dto.Donouts
{
    public class SalesDonoutsDTO : EntityDTO
    {
        public Guid? Id { get; set; }
        public UsersDTO? User { get; set; } = new UsersDTO();
        public TypeDonoutsDTO? TypeDonouts { get; set; } = new TypeDonoutsDTO();
        public int Amount { get; set; }
        public DateTime? SaleDate { get; set; }
    }
}
