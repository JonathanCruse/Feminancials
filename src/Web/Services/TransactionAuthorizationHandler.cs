using Azure;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using System.Reflection.Metadata;
using Feminancials.Domain.Entities.FinancialsAggregate;
using Feminancials.Web.Services;
using Feminancials.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
public class DocumentAuthorizationCrudHandler :
    AuthorizationHandler<OperationAuthorizationRequirement, Transaction>
{
    private readonly CurrentUser _currentUser;
    private readonly IApplicationDbContext _context;

    public DocumentAuthorizationCrudHandler(IApplicationDbContext context, CurrentUser currentUser) : base()
    {
        _context = context;
        _currentUser = currentUser;
    }


    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
                                                   OperationAuthorizationRequirement requirement,
                                                   Transaction resource)
    {
        Guard.Against.Null(_currentUser.Id);
        if (
        _context.Transactions
            .Include(x => x.Debtor)
            .ThenInclude(x => x.Collaborators)
            .First(x => x.Id == resource.Id && x.Debtor.Collaborators.Any(x => x.Id == _currentUser.Id))
            is not null)
        {
            context.Succeed(requirement);
        }

        return Task.CompletedTask;
    }

}
