namespace Messenger.Application.Domain;

public abstract class Channel
{
    public Guid Id { get; protected init; }
    public DateTime CreatedAt { get; protected init; }
    public DateTime UpdatedAt { get; protected set; }
    public List<Message> Messages { get; protected init; } = [];

    protected Channel()
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }
}