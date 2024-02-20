using Feminancials.Domain.Entities;
using Feminancials.Domain.Entities.FinancialsAggregate;
using Feminancials.Domain.Entities.UserAggregate;

namespace Feminancials.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<TodoList> TodoLists { get; }

    DbSet<TodoItem> TodoItems { get; }
    DbSet<Collective> Collectives { get; }
    DbSet<Expense> Expenses { get; }
    DbSet<Transaction> Transactions { get; }


    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
