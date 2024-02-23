using Azure;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using System.Reflection.Metadata;
using Feminancials.Domain.Entities.FinancialsAggregate;
using Feminancials.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Feminancials.Infrastructure.Identity;
using Ardalis.GuardClauses;
using Feminancials.Application.TodoLists.Commands.UpdateTodoList;
using Feminancials.Application.TodoLists.Commands.CreateTodoList;
using Feminancials.Domain.Entities.UserAggregate;

public record AccessCollectiveAuthorizationRequirement() : IAuthorizationRequirement;
public class AccessCollectiveAuthorizationHandler :
    AuthorizationHandler<AccessCollectiveAuthorizationRequirement, Collective>
{
    private readonly IApplicationDbContext _context;

    public AccessCollectiveAuthorizationHandler(IApplicationDbContext context) : base()
    {
        _context = context;
    }


    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
                                                   AccessCollectiveAuthorizationRequirement requirement,
                                                   Collective resource)
    {
        Guard.Against.Null(context.User);
        Guard.Against.Null(context.User.Identity);
        Guard.Against.Null(context.User.Identity.Name);
        //var user = _context.Feminists
        //    .Include(x => x.Collectives)
        //    .AsNoTracking()
        //    .First(x => x.UserName == context.User.Identity.Name);
        //Guard.Against.Null(user);


        //if (_context.FeministsCollectives
        //    .Include(x => x.Collective)
        //    .Where(x => x.FeministId == user.Id)
        //    .Any(x => x.CollectiveId == resource.Id))
        //{
        //    context.Succeed(requirement);
        //}

        return Task.CompletedTask;
    }

}
