using Messenger.API.Utils.Constants;
using Messenger.Application;
using Messenger.Application.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
// Retrieving environment variables
// Throwing ArgumentNullException if one of the environment variables is null
// To set environment variable you need to use -e [<NAME>=<VALUE>] while using "dotnet run"
var dbName = Environment.GetEnvironmentVariable(EnvironmentVariableConstants.DB_NAME) ??
             throw new ArgumentNullException(
                 nameof(EnvironmentVariableConstants.DB_NAME),
                 string.Format(
                     EnvironmentVariableConstants.ErrorMessage, 
                     Environment.GetEnvironmentVariable(EnvironmentVariableConstants.DB_NAME)));
var sqlPassword = Environment.GetEnvironmentVariable(EnvironmentVariableConstants.SQL_PASSWORD) ?? 
             throw new ArgumentNullException(
                 nameof(EnvironmentVariableConstants.SQL_PASSWORD),
                 string.Format(
                     EnvironmentVariableConstants.ErrorMessage,
                     Environment.GetEnvironmentVariable(EnvironmentVariableConstants.SQL_PASSWORD)));
var sqlUsername = Environment.GetEnvironmentVariable(EnvironmentVariableConstants.SQL_USERNAME) ?? 
             throw new ArgumentNullException(
                 nameof(EnvironmentVariableConstants.SQL_USERNAME),
                 string.Format(
                     EnvironmentVariableConstants.ErrorMessage,
                     Environment.GetEnvironmentVariable(EnvironmentVariableConstants.SQL_USERNAME)));
// Add services to the container.
{
    builder.Services
        .AddMessengerSchemas()
        .AddInfrastructure(dbName, sqlPassword, sqlUsername);
}

var app = builder.Build();

// Configure the HTTP request pipeline.

app.MapGraphQL();
app.UseHttpsRedirection();

app.Run();