using ErrorOr;

namespace Messenger.Application.Domain;

public enum CallParticipantStatus
{
    None,
    Deafened,
    Muted,
}

public sealed class CallParticipant
{
    private CallParticipant()
    {
    }

    private CallParticipant(
        User user,
        CallParticipantStatus status)
    {
        this.Id = Guid.NewGuid();
        this.User = user;
        this.UserId = user.Id;
        this.Status = status;
    }

    public Guid Id { get; private init; }
    public Guid UserId { get; private init; }
    public User User { get; private init; }
    public CallParticipantStatus Status { get; private set; }

    public static ErrorOr<CallParticipant> Create(
        in User user,
        in CallParticipantStatus status = CallParticipantStatus.None)
    {
        // Initializing CallParticipant
        var callParticipant = new CallParticipant(
            user,
            status);

        return callParticipant
            .ToErrorOr();
    }
}