using Azure;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using System.Reflection.Metadata;
using Feminancials.Domain.Entities.FinancialsAggregate;
using Feminancials.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

public record AccessExpenseAuthorizationRequirement() : IAuthorizationRequirement;
public class ExpenseAuthorizationHandler :
    AuthorizationHandler<AccessExpenseAuthorizationRequirement, Expense>
{
    private readonly IApplicationDbContext _context;

    public ExpenseAuthorizationHandler(IApplicationDbContext context) : base()
    {
        _context = context;
    }


    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
                                                   AccessExpenseAuthorizationRequirement requirement,
                                                   Expense resource)
    {
        Guard.Against.Null(context.User);
        Guard.Against.Null(context.User.Identity);
        Guard.Against.Null(context.User.Identity.Name);

        var join = from collective in _context.Collectives
                   join transaction in _context.Transactions on collective.Id equals transaction.DebtorId
                   select new { collective, transaction };
                   

        if (
        _context.Transactions
            .Include(x => x.Debtor)
            .ThenInclude(x => x.Collaborators)
            .First(x => x.Id == resource.Id && x.Debtor.Collaborators.Any(x => x.FeministId == ""))
            is not null)
        {
            context.Succeed(requirement);
        }

        return Task.CompletedTask;
    }

}
