namespace Messenger.Application.Domain;

public class DomainException(string message) : Exception(message)
{
    public string Message { get; private set; } = message;
}