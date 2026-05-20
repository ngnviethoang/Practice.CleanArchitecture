using MiniStore.Domain.Entities.Abstracts;

namespace MiniStore.Domain.Events;

public class EntityUpdatedEvent<T> : IDomainEvent
    where T : Entity<Guid>
{
    public EntityUpdatedEvent(T entity, DateTimeOffset eventDateTime)
    {
        Entity = entity;
        EventDateTime = eventDateTime;
    }

    public T Entity { get; }

    public DateTimeOffset EventDateTime { get; }
}