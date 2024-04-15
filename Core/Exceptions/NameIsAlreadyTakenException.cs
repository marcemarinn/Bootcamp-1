namespace Core.Exceptions;

public class NameIsAlreadyTakenException : Exception
{
    public NameIsAlreadyTakenException(string message) : base(message)
    {
    }
}
