namespace Messenger.Application.Features;

using HotChocolate.Execution.Configuration;
using Microsoft.Extensions.DependencyInjection;

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