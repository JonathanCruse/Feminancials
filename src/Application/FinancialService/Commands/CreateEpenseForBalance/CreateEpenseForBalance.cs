using Feminancials.Application.Common.Interfaces;

namespace Feminancials.Application.FinancialService.Commands.CreateEpenseForBalance;

public record CreateEpenseForBalanceCommand : IRequest<int>
{
}

public class CreateEpenseForBalanceCommandValidator : AbstractValidator<CreateEpenseForBalanceCommand>
{
    public CreateEpenseForBalanceCommandValidator()
    {
    }
}

public class CreateEpenseForBalanceCommandHandler : IRequestHandler<CreateEpenseForBalanceCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateEpenseForBalanceCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateEpenseForBalanceCommand request, CancellationToken cancellationToken)
    {
        await Task.Delay(1);
        throw new NotImplementedException();
    }
}
