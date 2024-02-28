using Feminancials.Application.FinancialService.Dtos;
using Feminancials.Application.Common.Interfaces;
using Feminancials.Application.Common.Models;
namespace Feminancials.Application.FinancialService.Queries.GetTransactionForExpense;

public record GetTransactionForExpenseQuery(int ExpenseId) : IRequest<TransactionDto>
{

}

public class GetTransactionForExpenseQueryValidator : AbstractValidator<GetTransactionForExpenseQuery>
{
    public GetTransactionForExpenseQueryValidator()
    {
    }
}

public class GetTransactionForExpenseQueryHandler : IRequestHandler<GetTransactionForExpenseQuery, TransactionDto>
{
    private readonly IApplicationDbContext _context;

    public GetTransactionForExpenseQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<TransactionDto> Handle(GetTransactionForExpenseQuery request, CancellationToken cancellationToken)
    {
        await Task.Delay(1);
        throw new NotImplementedException();
    }
}
