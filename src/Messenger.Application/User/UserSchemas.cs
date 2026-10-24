using HotChocolate.Execution.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Messenger.Application.User;

internal static class UserSchemas
{
    internal static IRequestExecutorBuilder AddUserSchemas(this IRequestExecutorBuilder services)
    {
        services
            .AddQueryType()
            .AddTypes(typeof(GetUserQuery));
        
        return services;
    }
}