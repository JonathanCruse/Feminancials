using Feminancials.Application.Common.Interfaces;
using Feminancials.Application.Common.Security;
using Feminancials.Domain.Constants;

namespace Feminancials.Application.TodoLists.Commands.PurgeTodoLists;

[Authorize(Roles = Roles.Administrator)]
[Authorize(Policy = Policies.CanPurge)]
public record PurgeTodoListsCommand : IRequest;

public class PurgeTodoListsCommandHandler : IRequestHandler<PurgeTodoListsCommand>
{
    private readonly IApplicationDbContext _context;

    public PurgeTodoListsCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(PurgeTodoListsCommand request, CancellationToken cancellationToken)
    {
        _context.TodoLists.RemoveRange(_context.TodoLists);

        await _context.SaveChangesAsync(cancellationToken);
    }
}
