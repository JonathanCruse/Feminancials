using System.Linq;
using Feminancials.Application.Common.Interfaces;
using Feminancials.Domain.Entities.FinancialsAggregate;
using Feminancials.Domain.Entities.UserAggregate;
using Feminancials.Domain.Events;
using Feminancials.Infrastructure.Identity;
using Microsoft.Extensions.Logging;

namespace Feminancials.Application.TodoItems.EventHandlers;

public class TransactionCreatedEventHandler : INotificationHandler<TransactionCreatedEvent>
{
    private readonly ILogger<TransactionCreatedEventHandler> _logger;
    private readonly IApplicationDbContext _dbContext;


    public TransactionCreatedEventHandler(ILogger<TransactionCreatedEventHandler> logger, IApplicationDbContext applicationDbContext)
    {
        _logger = logger;
        _dbContext = applicationDbContext;
    }

    public Task Handle(TransactionCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Feminancials Domain Event: {DomainEvent}", notification.GetType().Name);


        Collective debtor = _dbContext.Collectives
            .Include(collective => collective.Collaborators)
            .AsNoTracking()
            .First(x => x.Id == notification.Item.Debtor.Id);

        var amountPerFeminist = (notification.Item.Amount / debtor.Collaborators.Count());
        foreach (Feminist f in debtor.Collaborators)
        {

            _dbContext.Expenses.Add(new Expense
            {
                Amount = amountPerFeminist,
                Transaction = notification.Item,
                Debtor = f
            });
        }

        

        return _dbContext.SaveChangesAsync(cancellationToken);
    }
}
