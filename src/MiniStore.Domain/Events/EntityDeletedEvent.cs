using MiniStore.Domain.Entities.Abstracts;

namespace MiniStore.Domain.Events;

public class EntityDeletedEvent<T> : IDomainEvent
    where T : Entity<Guid>
{
    public EntityDeletedEvent(T entity, DateTimeOffset eventDateTime)
    {
        Entity = entity;
        EventDateTime = eventDateTime;
    }

    public T Entity { get; }

    public DateTimeOffset EventDateTime { get; }
}