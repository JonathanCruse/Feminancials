using Feminancials.Domain.Entities.FinancialsAggregate;

namespace Feminancials.Domain.Events;

public class TransactionDeletedEvent : BaseEvent
{
    public TransactionDeletedEvent(Transaction item)
    {
        Item = item;
    }

    public Transaction Item { get; }
}
