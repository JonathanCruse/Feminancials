using Feminancials.Application.Common.Interfaces;

namespace Feminancials.Application.Financials.Commands.DeleteTransaction;

public record DeleteTransactionCommand : IRequest<int>
{
    public int Id { get; set; }
}

public class DeleteTransactionCommandValidator : AbstractValidator<DeleteTransactionCommand>
{
    public DeleteTransactionCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThanOrEqualTo(1);
    }
}

public class DeleteTransactionCommandHandler : IRequestHandler<DeleteTransactionCommand, int>
{
    private readonly IApplicationDbContext _context;

    public DeleteTransactionCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(DeleteTransactionCommand request, CancellationToken cancellationToken)
    {
        await Task.Delay(1);
        throw new NotImplementedException();
    }
}
