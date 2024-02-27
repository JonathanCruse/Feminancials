using Feminancials.Application.Common.Interfaces;

namespace Feminancials.Application.FinancialService.Commands.DeleteCollective;

public record DeleteCollectiveCommand : IRequest<object>
{
}

public class DeleteCollectiveCommandValidator : AbstractValidator<DeleteCollectiveCommand>
{
    public DeleteCollectiveCommandValidator()
    {
    }
}

public class DeleteCollectiveCommandHandler : IRequestHandler<DeleteCollectiveCommand, object>
{
    private readonly IApplicationDbContext _context;

    public DeleteCollectiveCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<object> Handle(DeleteCollectiveCommand request, CancellationToken cancellationToken)
    {
        await Task.Delay(1);
        throw new NotImplementedException();
    }
}
