using ErrorOr;

namespace Messenger.Application.Domain;

public sealed class Call
{
    private Call()
    {
    }

    private Call(Channel channel)
    {
        this.Id = Guid.NewGuid();
        this.ChannelId = channel.Id;
        this.Channel = channel;
        this.CreatedAt = DateTime.UtcNow;
    }

    public Guid Id { get; private init; }
    public Guid ChannelId { get; private init; }
    public Channel Channel { get; private init; }
    public List<CallParticipant> CallParticipants { get; private init; } = [];
    public DateTime CreatedAt { get; private init; }

    public static ErrorOr<Call> Create(
        in Channel channel)
    {
        // Initializing Call
        var call = new Call(
            channel);

        return call
            .ToErrorOr();
    }
}