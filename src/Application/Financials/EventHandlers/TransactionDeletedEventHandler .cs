using Feminancials.Application.Common.Interfaces;
using Feminancials.Domain.Entities.FinancialsAggregate;
using Feminancials.Domain.Entities.UserAggregate;
using Feminancials.Domain.Events;
using Microsoft.Extensions.Logging;

namespace Feminancials.Application.Financials.EventHandlers;

public class TransactionDeletedEventHandler : INotificationHandler<TransactionCreatedEvent>
{
    private readonly ILogger<TransactionDeletedEventHandler> _logger;
    private readonly IApplicationDbContext _dbContext;


    public TransactionDeletedEventHandler(ILogger<TransactionDeletedEventHandler> logger, IApplicationDbContext applicationDbContext)
    {
        _logger = logger;
        _dbContext = applicationDbContext;
    }

    public Task Handle(TransactionCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Feminancials Domain Event: {DomainEvent}", notification.GetType().Name);
        
        return _dbContext.SaveChangesAsync(cancellationToken);
    }
}
