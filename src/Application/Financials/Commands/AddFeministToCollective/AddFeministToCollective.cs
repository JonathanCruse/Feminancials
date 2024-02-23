using Feminancials.Application.Common.Interfaces;

namespace Feminancials.Application.Financials.Commands.AddFeministToCollective;

public record AddFeministToCollectiveCommand : IRequest<int>
{
}

public class AddFeministToCollectiveCommandValidator : AbstractValidator<AddFeministToCollectiveCommand>
{
    public AddFeministToCollectiveCommandValidator()
    {
    }
}

public class AddFeministToCollectiveCommandHandler : IRequestHandler<AddFeministToCollectiveCommand, int>
{
    private readonly IApplicationDbContext _context;

    public AddFeministToCollectiveCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(AddFeministToCollectiveCommand request, CancellationToken cancellationToken)
    {
        await Task.Delay(1);
        throw new NotImplementedException();
    }
}
