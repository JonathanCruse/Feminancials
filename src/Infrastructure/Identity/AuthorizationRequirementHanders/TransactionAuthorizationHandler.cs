using Azure;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using System.Reflection.Metadata;
using Feminancials.Domain.Entities.FinancialsAggregate;
using Feminancials.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

public record AccessTransactionAuthorizationRequirement() : IAuthorizationRequirement;
public class AccessTransactionAuthorizationHandler :
    AuthorizationHandler<AccessTransactionAuthorizationRequirement, Transaction>
{
    private readonly IApplicationDbContext _context;

    public AccessTransactionAuthorizationHandler(IApplicationDbContext context) : base()
    {
        _context = context;
    }


    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
                                                   AccessTransactionAuthorizationRequirement requirement,
                                                   Transaction resource)
    {
        string userId = "";
        Guard.Against.Null(userId);
        if (
        _context.Transactions
            .Include(x => x.Debtor)
            .ThenInclude(x => x.Collaborators)
            .First(x => x.Id == resource.Id && x.Debtor.Collaborators.Any(x => x.FeministId == userId))
            is not null)
        {
            context.Succeed(requirement);
        }

        return Task.CompletedTask;
    }

}
