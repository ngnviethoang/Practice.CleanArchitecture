namespace MiniStore.Contract.CircuitBreakers;

public enum CircuitStatus
{
    Closed,
    Open,
    HalfOpen
}