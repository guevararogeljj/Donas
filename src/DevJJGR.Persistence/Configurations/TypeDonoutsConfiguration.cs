using Donouts.Domain.Entities.Donouts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donouts.Persistance.Configurations
{
    public class TypeDonoutsConfiguration : IEntityTypeConfiguration<TypeDonouts>
    {
        public void Configure(EntityTypeBuilder<TypeDonouts> builder)
        {
            builder.ToTable("TIPO_DONAS");
            builder.HasKey(x => x.Id);
        }
    }
}
