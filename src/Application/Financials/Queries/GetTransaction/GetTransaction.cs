using System.Security.Cryptography.X509Certificates;
using Feminancials.Application.Common.Interfaces;
using Feminancials.Application.Financials.Queries.GetTransactionsWithPagination;

namespace Feminancials.Application.Financials.Queries.GetTransaction;

public record GetTransactionQuery(int TransactionId) : IRequest<TransactionDto>
{

}

public class GetTransactionQueryValidator : AbstractValidator<GetTransactionQuery>
{
    public GetTransactionQueryValidator()
    {
        RuleFor(x => x.TransactionId)
           .GreaterThan(-1).WithMessage("transaction must be specified");
    }
}

public class GetTransactionQueryHandler : IRequestHandler<GetTransactionQuery, TransactionDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;


    public GetTransactionQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<TransactionDto> Handle(GetTransactionQuery request, CancellationToken cancellationToken)
    {
        var x =  _context.Transactions
            .Where(x => x.Id == request.TransactionId)
            .Include(x => x.Expenses);
    }
}
