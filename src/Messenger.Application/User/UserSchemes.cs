using HotChocolate.Execution.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Messenger.Application.User;

internal static class UserSchemes
{
    internal static IRequestExecutorBuilder AddUserScheme(this IRequestExecutorBuilder services)
    {
        services
            .AddQueryType()
            .AddTypes(typeof(GetUserQuery));
        
        return services;
    }
}