using Feminancials.Domain.Entities.FinancialsAggregate;

namespace Feminancials.Domain.Events;

public class TransactionCreatedEvent : BaseEvent
{
    public TransactionCreatedEvent(Transaction item)
    {
        Item = item;
    }

    public Transaction Item { get; }
}
