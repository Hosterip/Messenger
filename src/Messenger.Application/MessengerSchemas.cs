namespace Messenger.Application;

using Messenger.Application.Features;
using Microsoft.Extensions.DependencyInjection;

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