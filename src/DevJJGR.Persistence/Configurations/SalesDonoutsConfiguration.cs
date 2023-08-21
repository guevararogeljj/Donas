using Donouts.Domain.Entities.Donouts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Donouts.Persistance.Configurations
{
    public class SalesDonoutsConfiguration : IEntityTypeConfiguration<SalesDonouts>
    {
        public void Configure(EntityTypeBuilder<SalesDonouts> builder)
        {
            builder.ToTable("VENTAS_DONAS");
            builder.HasKey(x => x.Id);
        }
    }
}
