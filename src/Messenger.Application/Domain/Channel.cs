namespace Messenger.Application.Domain;

public abstract class Channel
{
    protected Channel()
    {
        this.Id = Guid.NewGuid();
        this.CreatedAt = DateTime.UtcNow;
        this.UpdatedAt = DateTime.UtcNow;
    }

    public Guid Id { get; protected init; }
    public DateTime CreatedAt { get; protected init; }
    public DateTime UpdatedAt { get; protected set; }
    public List<Message> Messages { get; protected init; } = [];
}