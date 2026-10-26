namespace Messenger.Application.Domain;

using System.Security.Cryptography;
using ErrorOr;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Error = ErrorOr.Error;

public enum ActivityStatus
{
    Online,
    Offline
}

public enum ActivityPreference
{
    None,
    DoNotDisturb,
    Invisible
}

public sealed class User
{
    public Guid Id { get; private init; }
    public string Username { get; private set; }
    public string DisplayName { get; private set; }
    public string PasswordHash { get; private set; }
    public string Email { get; private set; }
    public DateTime CreatedAt  { get; private init; }
    public DateTime UpdatedAt { get; private set; }
    public string? AvatarUrl { get; private set; }
    public ActivityStatus ActivityStatus { get; private set; }
    public ActivityPreference ActivityPreference { get; private set; }
    
    private User (
        string username,
        string displayName,
        string passwordHash,
        string email, 
        ActivityStatus activityStatus,
        ActivityPreference activityPreference = ActivityPreference.None)
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

    public static ErrorOr<User> Create(
        in string username,
        in string password, 
        in string email)
    {
        List<Error> errors = [
            .. ValidateUsername(username)
        ];
        
        if(errors.Count != 0) return errors;
        
        var hashedPassword = HashPassword(password);
        
        // Initializing User
        var user = new User(
            username: username,
            displayName: username,
            passwordHash: hashedPassword,
            email: email,
            activityStatus: ActivityStatus.Offline);
        
        return user
            .ToErrorOr();
    }
    
    // ValidateUsername returns true if everything is in order
    private static List<Error> ValidateUsername(in string username)
    {
        List<Error> errors = [];
        if(username.Length <= 3) errors.Add(Error.Validation(description: "Username is too short")); 
        if(username.Length >= 255) errors.Add(Error.Validation(description: "Username is too long")); 
        if(!string.IsNullOrWhiteSpace(username)) errors.Add(Error.Validation(description: "Username cannot contain whitespaces"));
        return errors;
    }

    private static string HashPassword(in string password)
    {
        // Generate a 128-bit salt 
        var salt = RandomNumberGenerator.GetBytes(128 / 8);
        
        // Creating a hash with HMACSHA256
        string hashedPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 100000,
            numBytesRequested: 256 / 8));
       
        // Returning hashed password
        return hashedPassword;
    }
}