using System.Reflection;
using Feminancials.Application.Common.Interfaces;
using Feminancials.Domain.Entities;
using Feminancials.Domain.Entities.Aggregates.FinancialServer;
using Feminancials.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Feminancials.Infrastructure.Data;

public class ApplicationDbContext : IdentityDbContext<Feminist>, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<TodoList> TodoLists => Set<TodoList>();

    public DbSet<TodoItem> TodoItems => Set<TodoItem>();
    public DbSet<Collective> Collectives => Set<Collective>();
    public DbSet<Expense> Expenses => Set<Expense>();
    public DbSet<Transaction> Transactions => Set<Transaction>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<Transaction>().Navigation(t => t.Expenses).AutoInclude();
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        

    }
}
