namespace Messenger.Application.Features;

using ErrorOr;
using Messenger.Application.Domain;

[QueryType]
public static partial class UserQuery
{
    public static ErrorOr<User> GetUser()
    {
        var user = User.Create(username: "Ryan", password: "1234", email: "email@email.com");
        return user;
    }
}