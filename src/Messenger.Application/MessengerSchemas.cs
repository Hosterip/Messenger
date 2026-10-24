using Messenger.Application.User;
using Microsoft.Extensions.DependencyInjection;

namespace Messenger.Application;

public static class MessengerSchemas
{
    public static IServiceCollection AddMessengerSchemas(this IServiceCollection services)
    {
        services
            .AddGraphQLServer()
            .AddUserSchemas();

        return services;
    }
}