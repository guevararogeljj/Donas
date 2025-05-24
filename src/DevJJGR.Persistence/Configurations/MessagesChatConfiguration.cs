using Donouts.Domain.Entities.Messages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Donouts.Persistance.Configurations;

public class MessagesChatConfiguration : IEntityTypeConfiguration<MessagesChat>
{
    public void Configure(EntityTypeBuilder<MessagesChat> builder)
    {
        builder.ToTable("MessagesChat");
        builder.HasKey(m => m.Id);
        builder.Property(m => m.User).IsRequired().HasMaxLength(100);
        builder.Property(m => m.Content).IsRequired().HasMaxLength(500);
        builder.Property(m => m.CreatedAt).IsRequired();
    }
}