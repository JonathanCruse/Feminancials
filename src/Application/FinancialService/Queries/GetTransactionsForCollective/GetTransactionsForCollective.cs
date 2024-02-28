using Feminancials.Application.FinancialService.Dtos;
using Feminancials.Application.Common.Interfaces;
using Feminancials.Application.Common.Models;

namespace Feminancials.Application.FinancialService.Queries.GetTransactionsForCollective;

public record GetTransactionsForCollectiveQuery(int CollectiveId) : IRequest<PaginatedList<TransactionDto>>
{
}

public class GetTransactionsForCollectiveQueryValidator : AbstractValidator<GetTransactionsForCollectiveQuery>
{
    public GetTransactionsForCollectiveQueryValidator()
    {
    }
}

public class GetTransactionsForCollectiveQueryHandler : IRequestHandler<GetTransactionsForCollectiveQuery, PaginatedList<TransactionDto>>
{
    private readonly IApplicationDbContext _context;

    public GetTransactionsForCollectiveQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<PaginatedList<TransactionDto>> Handle(GetTransactionsForCollectiveQuery request, CancellationToken cancellationToken)
    {
        await Task.Delay(1);
        throw new NotImplementedException();
    }
}
