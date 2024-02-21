using Azure;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using System.Reflection.Metadata;
using Feminancials.Domain.Entities.FinancialsAggregate;
using Feminancials.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

public record AccessCollectiveAuthorizationRequirement() : IAuthorizationRequirement;
public class AccessCollectiveAuthorizationHandler :
    AuthorizationHandler<AccessCollectiveAuthorizationRequirement>
{
    private readonly IApplicationDbContext _context;

    public AccessCollectiveAuthorizationHandler(IApplicationDbContext context) : base()
    {
        _context = context;
    }


    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
                                                   AccessCollectiveAuthorizationRequirement requirement)
    {
        string userId = "";
        var resourceId = 0;
        Guard.Against.Null(userId);
        if (
        _context.Transactions
            .Include(x => x.Debtor)
            .ThenInclude(x => x.Collaborators)
            .First(x => x.Id == resourceId && x.Debtor.Collaborators.Any(x => x.Id == userId))
            is not null)
        {
            context.Succeed(requirement);
        }

        return Task.CompletedTask;
    }

}
