using System.ComponentModel;
using System.Linq;
using Feminancials.Application.Common.Interfaces;
using Feminancials.Domain.Entities.FinancialsAggregate;
using Feminancials.Domain.Entities.UserAggregate;
using Feminancials.Domain.Events;
using Feminancials.Infrastructure.Identity;
using Microsoft.Extensions.Logging;
using static System.Formats.Asn1.AsnWriter;

namespace Feminancials.Application.Financials.EventHandlers;

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
            .First(x => x.Id == notification.Item.Debtor.Id);

        //foreach ((FeministsCollectives feminist, float scale) item in debtor.GetWeightedCollaborators())
        //{
        //    var amount = notification.Item.CreditorId == item.feminist.FeministId ? notification.Item.Amount * item.scale - notification.Item.Amount : notification.Item.Amount * item.scale;
        //    _dbContext.Expenses.Add(new Expense
        //    {
        //        Amount = amount,
        //        Transaction = notification.Item,
        //        DebtorId = item.feminist.FeministId
        //    });
        //    item.feminist.CurrentDebt += amount;
        //}
        return _dbContext.SaveChangesAsync(cancellationToken);
    }
}
