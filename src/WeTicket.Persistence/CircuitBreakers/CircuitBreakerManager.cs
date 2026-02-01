using Microsoft.EntityFrameworkCore;
using WeTicket.Contract.CircuitBreakers;
using WeTicket.Contract.Providers;

namespace WeTicket.Persistence.CircuitBreakers;

public class CircuitBreakerManager : ICircuitBreakerManager, IDisposable
{
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly WeTicketDbContext _dbContext;

    public CircuitBreakerManager(IDbContextFactory<WeTicketDbContext> dbContextFactory, IDateTimeProvider dateTimeProvider)
    {
        _dbContext = dbContextFactory.CreateDbContext();
        _dateTimeProvider = dateTimeProvider;
    }

    public void Dispose()
    {
        _dbContext.Dispose();
    }

    public async Task<ICircuitBreaker> GetCircuitBreaker(string name, TimeSpan openTime)
    {
        CircuitBreaker? circuitBreaker = GetCircuitBreakerByName(name);
        if (circuitBreaker == null)
        {
            try
            {
                circuitBreaker = new CircuitBreaker
                {
                    Name = name,
                    Status = CircuitStatus.Closed,
                    CreationTime = _dateTimeProvider.UtcNow,
                    LastModificationTime = _dateTimeProvider.UtcNow
                };

                await _dbContext.Set<CircuitBreaker>().AddAsync(circuitBreaker);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                circuitBreaker = GetCircuitBreakerByName(name);
                if (circuitBreaker == null)
                {
                    throw;
                }
            }
        }

        if (circuitBreaker.Status == CircuitStatus.Open && circuitBreaker.LastModificationTime + openTime <= _dateTimeProvider.UtcNow)
        {
            circuitBreaker.Status = CircuitStatus.HalfOpen;
            circuitBreaker.LastModificationTime = _dateTimeProvider.UtcNow;
            await _dbContext.SaveChangesAsync();
        }

        return circuitBreaker;
    }

    private CircuitBreaker? GetCircuitBreakerByName(string name)
    {
        return _dbContext.Set<CircuitBreaker>().FirstOrDefault(i => string.Equals(i.Name, name));
    }

    public void LogFailure(ICircuitBreaker circuitBreaker, int maximumNumberOfFailures, TimeSpan period)
    {
        CircuitBreaker circuitBreakerObject = (CircuitBreaker)circuitBreaker;

        _dbContext.Set<CircuitBreakerLog>().Add(new CircuitBreakerLog
        {
            Id = Guid.NewGuid(),
            CircuitBreakerId = circuitBreakerObject.Id,
            Status = circuitBreakerObject.Status,
            Succeeded = false,
            CreationTime = _dateTimeProvider.UtcNow
        });

        UpdateCircuitBreakerStatus(circuitBreaker, circuitBreaker.Status == CircuitStatus.HalfOpen, CircuitStatus.Open);

        _dbContext.SaveChanges();

        if (circuitBreaker.Status == CircuitStatus.Closed)
        {
            DateTimeOffset sinceLastTime = _dateTimeProvider.OffsetNow - period;
            int numberOfFailures = _dbContext.Set<CircuitBreakerLog>().Count(x => x.CircuitBreakerId == circuitBreakerObject.Id
                                                                                  && !x.Succeeded && x.CreationTime >= sinceLastTime);
            UpdateCircuitBreakerStatus(circuitBreaker, numberOfFailures >= maximumNumberOfFailures, CircuitStatus.Open);

            _dbContext.SaveChanges();
        }
    }

    public void LogSuccess(ICircuitBreaker circuitBreaker)
    {
        CircuitBreaker circuitBreakerObject = (CircuitBreaker)circuitBreaker;

        _dbContext.Set<CircuitBreakerLog>().Add(new CircuitBreakerLog
        {
            Id = Guid.NewGuid(),
            CircuitBreakerId = circuitBreakerObject.Id,
            Status = circuitBreakerObject.Status,
            Succeeded = true,
            CreationTime = _dateTimeProvider.UtcNow
        });

        UpdateCircuitBreakerStatus(circuitBreaker, circuitBreaker.Status == CircuitStatus.HalfOpen, CircuitStatus.Closed);

        _dbContext.SaveChanges();
    }

    private void UpdateCircuitBreakerStatus(ICircuitBreaker circuitBreaker, bool shouldUpdate, CircuitStatus circuitStatus)
    {
        if (!shouldUpdate)
        {
            return;
        }

        circuitBreaker.Status = circuitStatus;
        circuitBreaker.LastModificationTime = _dateTimeProvider.UtcNow;
    }
}