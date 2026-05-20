using MiniStore.Domain.Entities.Abstracts;

namespace MiniStore.Domain.Events;

public class EntityCreatedEvent<T> : IDomainEvent
    where T : Entity<Guid>
{
    public EntityCreatedEvent(T entity, DateTimeOffset eventDateTime)
    {
        Entity = entity;
        EventDateTime = eventDateTime;
    }

    public T Entity { get; }

    public DateTimeOffset EventDateTime { get; }
}