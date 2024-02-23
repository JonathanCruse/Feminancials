using Feminancials.Application.Common.Interfaces;

namespace Feminancials.Application.Financials.Commands.DeleteCollective;

public record DeleteCollectiveCommand : IRequest<int>
{
    public int Id { get; set; }
}

public class DeleteCollectiveCommandValidator : AbstractValidator<DeleteCollectiveCommand>
{
    public DeleteCollectiveCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThanOrEqualTo(1);
    }
}

public class DeleteCollectiveCommandHandler : IRequestHandler<DeleteCollectiveCommand, int>
{
    private readonly IApplicationDbContext _context;

    public DeleteCollectiveCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(DeleteCollectiveCommand request, CancellationToken cancellationToken)
    {
        await Task.Delay(1);
        throw new NotImplementedException();
    }
}
