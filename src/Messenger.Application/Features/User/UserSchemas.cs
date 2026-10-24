using HotChocolate.Execution.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Messenger.Application.Features;

internal static class UserSchemas
{
    internal static IRequestExecutorBuilder AddUserSchemas(this IRequestExecutorBuilder services)
    {
        services
            .AddQueryType()
            .AddTypes(typeof(UserQuery));
        
        return services;
    }
}