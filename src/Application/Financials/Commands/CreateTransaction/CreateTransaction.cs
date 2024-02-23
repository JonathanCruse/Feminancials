using Feminancials.Application.Common.Interfaces;

namespace Feminancials.Application.Financials.Commands.CreateTransaction;

public record CreateTransactionCommand : IRequest<int>
{
}

public class CreateTransactionCommandValidator : AbstractValidator<CreateTransactionCommand>
{
    public CreateTransactionCommandValidator()
    {
    }
}

public class CreateTransactionCommandHandler : IRequestHandler<CreateTransactionCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateTransactionCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
    {
        await Task.Delay(1);

        throw new NotImplementedException();
    }
}
