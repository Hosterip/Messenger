using Messenger.Application.User;
using Microsoft.Extensions.DependencyInjection;

namespace Messenger.Application;

public static class MessengerGraphQL
{
    public static IServiceCollection AddMessengerGraphQL(this IServiceCollection services)
    {
        services
            .AddGraphQLServer()
            .AddUserGraphQL();

        return services;
    }
}