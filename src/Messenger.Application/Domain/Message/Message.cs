using ErrorOr;

namespace Messenger.Application.Domain;

public sealed class Message
{
    private Message()
    {
    }

    private Message(
        string content,
        User user,
        Channel channel,
        Guid? parentMessageId)
    {
        this.Id = Guid.NewGuid();
        this.CreatedAt = DateTime.UtcNow;
        this.UpdatedAt = DateTime.UtcNow;
        this.Content = content;
        this.User = user;
        this.UserId = user.Id;
        this.Channel = channel;
        this.ChannelId = channel.Id;
        this.ParentMessageId = parentMessageId;
    }

    public Guid Id { get; private init; }
    public DateTime CreatedAt { get; private init; }
    public DateTime UpdatedAt { get; private set; }
    public string Content { get; private set; }
    public List<Attachment> Attachments { get; private init; } = [];
    public User User { get; private init; }
    public Channel Channel { get; private init; }
    public Guid UserId { get; private init; }
    public Guid ChannelId { get; private init; }
    public Guid? ParentMessageId { get; private init; }

    public static ErrorOr<Message> Create(
        string content,
        User user,
        Channel channel,
        Guid? parentMessageId,
        List<Attachment> attachments
    )
    {
        var message = new Message(
            content,
            user,
            channel,
            parentMessageId);

        message.Attachments.AddRange(attachments);

        return message
            .ToErrorOr();
    }
}