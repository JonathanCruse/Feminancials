using Feminancials.Application.Common.Interfaces;

namespace Feminancials.Application.FinancialService.Commands.CreateCollective;

public record CreateCollectiveCommand : IRequest<int>
{
}

public class CreateCollectiveCommandValidator : AbstractValidator<CreateCollectiveCommand>
{
    public CreateCollectiveCommandValidator()
    {
    }
}

public class CreateCollectiveCommandHandler : IRequestHandler<CreateCollectiveCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateCollectiveCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateCollectiveCommand request, CancellationToken cancellationToken)
    {
        await Task.Delay(1);
        throw new NotImplementedException();
    }
}
