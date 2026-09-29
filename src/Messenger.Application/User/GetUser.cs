using HotChocolate.Types;

namespace Messenger.Application.User;

[QueryType]
public static partial class GetUserQuery
{
    public static Domain.User GetUser()
    {
        var user = Domain.User.Create(username: "Ryan", password: "1234", email: "email@email.com");

        return user;
    }
}

