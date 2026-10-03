using Messenger.Application;
using Messenger.Application.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
var dbName = Environment.GetEnvironmentVariable("DB_NAME");
var sqlPassword = Environment.GetEnvironmentVariable("SQL_PASSWORD");
var sqlUsername = Environment.GetEnvironmentVariable("SQL_USERNAME");
ArgumentNullException.ThrowIfNull(dbName);
ArgumentNullException.ThrowIfNull(sqlPassword);
ArgumentNullException.ThrowIfNull(sqlUsername);
// Add services to the container.
{
    builder.Services
        .AddMessengerScheme()
        .AddInfrastructure(dbName, sqlPassword, sqlUsername);
}

var app = builder.Build();

// Configure the HTTP request pipeline.

app.MapGraphQL();
app.UseHttpsRedirection();

app.Run();