using Messenger.Application.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Messenger.Application.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, string dbName, string sqlPassword, string sqlUsername)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer($"Server=localhost;Database={dbName};User Id={sqlUsername};Password={sqlPassword};Trusted_Connection=True;");
        });
        
        return services;
    }
}