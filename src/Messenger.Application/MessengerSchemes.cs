using Messenger.Application.User;
using Microsoft.Extensions.DependencyInjection;

namespace Messenger.Application;

public static class MessengerSchemes
{
    public static IServiceCollection AddMessengerScheme(this IServiceCollection services)
    {
        services
            .AddGraphQLServer()
            .AddUserScheme();

        return services;
    }
}