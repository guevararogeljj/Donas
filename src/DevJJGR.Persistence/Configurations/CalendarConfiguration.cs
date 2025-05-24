
using Donouts.Domain.Entities.Activities;
using Donouts.Domain.Entities.Calendario;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Donouts.Persistance.Configurations
{
	public class CalendarConfiguration : IEntityTypeConfiguration<CalendarioActividades>
    {
        public void Configure(EntityTypeBuilder<CalendarioActividades> builder)
        {
            builder.ToTable("CALENDARIOACTIVIDADES");
            builder.HasKey(x => x.Id);
        }
    }
}

