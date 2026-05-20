namespace MiniStore.Contract.CircuitBreakers;

public class CircuitBreakerOpenException : Exception
{
    public CircuitBreakerOpenException()
    {
    }

    public CircuitBreakerOpenException(string message)
        : base(message)
    {
    }

    public CircuitBreakerOpenException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}