using ErrorOr;

namespace Messenger.Application.Domain;

public enum CallParticipantStatus
{
    None, 
    Deafened,
    Muted
}

public sealed class CallParticipant
{
    public Guid Id { get; private init; }
    public Guid UserId { get; private init; }
    public User User { get; private init; }
    public CallParticipantStatus Status { get; private set; }
    
    private CallParticipant() {}

    private CallParticipant(
        User user, 
        CallParticipantStatus status)
    {
        Id = Guid.NewGuid();
        User = user;
        UserId = user.Id;
        Status = status;
    }

    public static ErrorOr<CallParticipant> Create(
        in User user,
        in CallParticipantStatus status = CallParticipantStatus.None)
    {
        // Initializing CallParticipant
        var callParticipant = new CallParticipant(
            user: user,
            status: status);
        
        return callParticipant 
            .ToErrorOr();
    }
}