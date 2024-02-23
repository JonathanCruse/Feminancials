using Feminancials.Application.Common.Interfaces;

namespace Feminancials.Application.Financials.Commands.UpdateTransaction;

public record UpdateTransactionCommand : IRequest<int>
{
}

public class UpdateTransactionCommandValidator : AbstractValidator<UpdateTransactionCommand>
{
    public UpdateTransactionCommandValidator()
    {
    }
}

public class UpdateTransactionCommandHandler : IRequestHandler<UpdateTransactionCommand, int>
{
    private readonly IApplicationDbContext _context;

    public UpdateTransactionCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(UpdateTransactionCommand request, CancellationToken cancellationToken)
    {
        await Task.Delay(1);

        throw new NotImplementedException();
    }
}
