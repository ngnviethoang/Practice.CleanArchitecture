namespace WeTicket.Contract.CircuitBreakers;

public interface ICircuitBreaker
{
    string Name { get; set; }

    CircuitStatus Status { get; set; }

    DateTimeOffset LastModificationTime { get; set; }

    void EnsureOkStatus();
}