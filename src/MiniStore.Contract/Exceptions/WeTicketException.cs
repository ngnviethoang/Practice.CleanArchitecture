namespace MiniStore.Contract.Exceptions;

public class MiniStoreException : Exception
{
    public MiniStoreException(string message) : base(message)
    {
    }

    public MiniStoreException(string message, Exception innerException) : base(message, innerException)
    {
    }
}