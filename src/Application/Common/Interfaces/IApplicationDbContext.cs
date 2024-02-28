using Feminancial.Domain.Entities;
using Feminancials.Domain.Entities;

namespace Feminancials.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    public DbSet<TodoList> TodoLists { get; }

    public DbSet<TodoItem> TodoItems { get; }
    public DbSet<Collective> Collectives { get; }
    public DbSet<Feminist> Feminists { get; }
    public DbSet<FeministCollective> FeministCollectives { get; }
    public DbSet<Transaction> Transactions { get; }
    public DbSet<Expense> Expenses { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
