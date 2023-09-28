using System;
using Donouts.Domain.Entities.Activities;
using Donouts.Domain.Entities.Donouts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Donouts.Persistance.Configurations
{
	public class ActivitiesConfiguration : IEntityTypeConfiguration<Activities>
    {
        public void Configure(EntityTypeBuilder<Activities> builder)
        {
            builder.ToTable("ACTIVIDADES");
            builder.HasKey(x => x.Id);
        }
    }
}

