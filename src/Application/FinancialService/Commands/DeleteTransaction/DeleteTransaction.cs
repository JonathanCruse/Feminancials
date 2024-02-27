using Feminancials.Application.Common.Interfaces;

namespace Feminancials.Application.FinancialService.Commands.DeleteTransaction;

public record DeleteTransactionCommand : IRequest<object>
{
}

public class DeleteTransactionCommandValidator : AbstractValidator<DeleteTransactionCommand>
{
    public DeleteTransactionCommandValidator()
    {
    }
}

public class DeleteTransactionCommandHandler : IRequestHandler<DeleteTransactionCommand, object>
{
    private readonly IApplicationDbContext _context;

    public DeleteTransactionCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<object> Handle(DeleteTransactionCommand request, CancellationToken cancellationToken)
    {
        await Task.Delay(1);
        throw new NotImplementedException();
    }
}
