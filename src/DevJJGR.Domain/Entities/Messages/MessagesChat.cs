using Donouts.Domain.Common;

namespace Donouts.Domain.Entities.Messages;

public class MessagesChat : Entity
{
    public int Id { get; set; }
    public string User { get; set; } = String.Empty;
    public string Content { get; set; } = String.Empty;
}

