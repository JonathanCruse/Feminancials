using System.Runtime.InteropServices;
using Feminancials.Application.Financials.Dtos;
using Feminancials.Domain.Constants;
using Feminancials.Domain.Entities;
using Feminancials.Domain.Entities.FinancialsAggregate;
using Feminancials.Domain.Entities.UserAggregate;
using Feminancials.Infrastructure.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Feminancials.Infrastructure.Data;

public static class InitialiserExtensions
{
    public static async Task InitialiseDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var initialiser = scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitialiser>();

        await initialiser.InitialiseAsync();

        await initialiser.SeedAsync();
    }
}

public class ApplicationDbContextInitialiser
{
    private readonly ILogger<ApplicationDbContextInitialiser> _logger;
    private readonly ApplicationDbContext _context;
    private readonly UserManager<Feminist> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public ApplicationDbContextInitialiser(ILogger<ApplicationDbContextInitialiser> logger, ApplicationDbContext context, UserManager<Feminist> userManager, RoleManager<IdentityRole> roleManager)
    {
        _logger = logger;
        _context = context;
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task InitialiseAsync()
    {
        try
        {
            await _context.Database.MigrateAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initialising the database.");
            throw;
        }
    }

    public async Task SeedAsync()
    {
        try
        {
            await TrySeedAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while seeding the database.");
            throw;
        }
    }

    public async Task TrySeedAsync()
    {
        // Default roles
        var administratorRole = new IdentityRole(Roles.Administrator);

        if (_roleManager.Roles.All(r => r.Name != administratorRole.Name))
        {
            await _roleManager.CreateAsync(administratorRole);
        }

        // Default users
        var administrator = new Feminist { UserName = "administrator@localhost", Email = "administrator@localhost" };
        var feminist1 = new Feminist { UserName = "feminist1@localhost", Email = "feminist1@localhost" };
        var feminist2 = new Feminist { UserName = "feminist2@localhost", Email = "feminist2@localhost" };
        var feminist3 = new Feminist { UserName = "feminist3@localhost", Email = "feminist3@localhost" };
        if (_userManager.Users.All(u => u.UserName != administrator.UserName))
        {
            await _userManager.CreateAsync(administrator, "Administrator1!");
            await _userManager.CreateAsync(feminist1, "Administrator1!");
            await _userManager.CreateAsync(feminist2, "Administrator1!");
            await _userManager.CreateAsync(feminist3, "Administrator1!");
            if (!string.IsNullOrWhiteSpace(administratorRole.Name))
            {
                await _userManager.AddToRolesAsync(administrator, new [] { administratorRole.Name });
                await _userManager.AddToRolesAsync(feminist1, new [] { administratorRole.Name });
                await _userManager.AddToRolesAsync(feminist2, new [] { administratorRole.Name });
                await _userManager.AddToRolesAsync(feminist3, new [] { administratorRole.Name });
            }
        }

        // Default data
        // Seed, if necessary
        if (!_context.TodoLists.Any())
        {
            _context.TodoLists.Add(new TodoList
            {
                Title = "Todo List",
                Items =
                {
                    new TodoItem { Title = "Make a todo list 📃" },
                    new TodoItem { Title = "Check off the first item ✅" },
                    new TodoItem { Title = "Realise you've already done two things on the list! 🤯"},
                    new TodoItem { Title = "Reward yourself with a nice, long nap 🏆" },
                }
            });
            await _context.SaveChangesAsync();
        }
        var collective = new Domain.Entities.UserAggregate.Collective
        {
            Collaborators = new List<FeministsCollectives>(),
            Name = "Das Kollektiv",
            Description = "Das ist ein Test"
        };
        ICollection< FeministsCollectives> feministCollabs = [
            new FeministsCollectives { Feminist = feminist1, Collective = collective }
            , new FeministsCollectives { Feminist = feminist2, Collective = collective }
            ,new FeministsCollectives { Feminist = feminist3, Collective = collective }];
        collective.Collaborators = feministCollabs;
        if (!_context.Collectives.Any())
        {
            _context.Collectives.Add(collective);
            await _context.SaveChangesAsync();
        }
        if (!_context.Transactions.Any())
        {
            Transaction transaction = new Transaction
            {
                Creditor = feminist1,
                Debtor = collective,
                Description = "Das ist eine Beschribung",
                Expenses = new List<Expense>(),
                Amount = 6.0f
            };
            transaction.Expenses =
            [
                new Expense { 
                    Debtor = feminist1,
                    Amount = -4f,
                    Transaction = transaction
                },
                new Expense {
                    Debtor = feminist2,
                    Amount = 2f,
                    Transaction = transaction
                },
                new Expense {
                    Debtor = feminist3,
                    Amount = 2f,
                    Transaction = transaction
                }
            ];
            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();
        }
    }
}
