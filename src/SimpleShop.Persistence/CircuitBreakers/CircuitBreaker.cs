using SimpleShop.Contract.CircuitBreakers;

namespace SimpleShop.Persistence.CircuitBreakers;

public class CircuitBreaker : ICircuitBreaker
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }

    public CircuitStatus Status { get; set; }

    public DateTimeOffset LastModificationTime { get; set; }

    public DateTimeOffset CreationTime { get; set; }

    public ICollection<CircuitBreakerLog> CircuitBreakerLogs { get; set; }

    public void EnsureOkStatus()
    {
        if (Status == CircuitStatus.Open)
        {
            throw new CircuitBreakerOpenException();
        }
    }
}