using HotChocolate.Execution.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Messenger.Application.User;

internal static class UserGraphQL
{
    internal static IRequestExecutorBuilder AddUserGraphQL(this IRequestExecutorBuilder services)
    {
        services
            .AddQueryType()
            .AddTypes(typeof(GetUserQuery));
        
        return services;
    }
}