namespace Messenger.Application.Domain;

public sealed class Friendship
{
   public Guid Id { get; private init; }
   public DateTime CreatedAt { get; private init; }
   public DateTime UpdatedAt { get; private set; }
}