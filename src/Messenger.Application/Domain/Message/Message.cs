using ErrorOr;

namespace Messenger.Application.Domain;

public sealed class Message
{
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
    
    private Message () {}

    private Message(
        string content,
        User user,
        Channel channel,
        Guid? parentMessageId)
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
        Content = content;
        User = user;
        UserId = user.Id;
        Channel = channel;
        ChannelId = channel.Id;
        ParentMessageId = parentMessageId;
    }

    public static ErrorOr<Message> Create(
        string content,
        User user,
        Channel channel,
        Guid? parentMessageId,
        List<Attachment> attachments
    )
    {
        var message = new Message(
            content: content,
            user: user,
            channel: channel,
            parentMessageId: parentMessageId);
        
        message.Attachments.AddRange(attachments);
        
        return message
            .ToErrorOr();
    }
}