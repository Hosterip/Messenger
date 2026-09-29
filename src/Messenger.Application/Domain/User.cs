using System.Runtime.CompilerServices;

namespace Messenger.Application.Domain;

public enum ActivityStatus
{
    Online,
    Offline
}

public enum ActivityPreference
{
    Actual,
    DoNotDisturb,
    Invisible
}

public class User
{
    public Guid Id { get; init; }
    public string Username { get; private set; }
    public string DisplayName { get; private set; }
    public string PasswordHash { get; private set; }
    public string Email { get; private set; }
    public DateTime CreatedAt  { get; private init; }
    public DateTime UpdatedAt { get; private set; }
    public string? AvatarUrl { get; private set; }
    public ActivityStatus ActivityStatus { get; private set; }
    public ActivityPreference ActivityPreference { get; private set; }
    
    private User (string username, string displayName, string passwordHash, string email, ActivityStatus activityStatus, ActivityPreference activityPreference)
    {
        Id = Guid.NewGuid();
        Username = username;
        DisplayName = displayName;
        PasswordHash = passwordHash;
        Email = email;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
        ActivityStatus = activityStatus;
        ActivityPreference = activityPreference;
    }

    public static User Create(string username,  string password, string email)
    {
        return ValidateUsername(username)
            ? new User(username, username, password, email, ActivityStatus.Offline, ActivityPreference.Actual)
            : throw new DomainException("Invalid username");

    }
    
    private static bool ValidateUsername(string username)
    {
        return username.Length >= 3 && username.Length <= 255 && !string.IsNullOrWhiteSpace(username);
    }
}