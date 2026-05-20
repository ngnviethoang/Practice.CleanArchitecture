using MiniStore.Contract.CircuitBreakers;

namespace MiniStore.Persistence.CircuitBreakers;

public class CircuitBreakerLog
{
    public Guid Id { get; set; }

    public Guid CircuitBreakerId { get; set; }

    public CircuitStatus Status { get; set; }

    public bool Succeeded { get; set; }

    public DateTimeOffset CreationTime { get; set; }
}