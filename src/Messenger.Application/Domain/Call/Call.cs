using ErrorOr;

namespace Messenger.Application.Domain;

public sealed class Call
{
    public Guid Id { get; private init; } 
    public Guid ChannelId { get; private init; }
    public Channel Channel { get; private init; }
    public List<CallParticipant> CallParticipants { get; private init; } = [];
    public DateTime CreatedAt { get; private init; }
    
    private Call () {}

    private Call(Channel channel)
    {
        Id =  Guid.NewGuid();
        ChannelId = channel.Id;
        Channel = channel;
        CreatedAt = DateTime.UtcNow;
    }

    public static ErrorOr<Call> Create(
        in Channel channel)
    {
        // Initializing Call
        var call = new Call(
            channel: channel);
        
        return call
            .ToErrorOr();
    }
}