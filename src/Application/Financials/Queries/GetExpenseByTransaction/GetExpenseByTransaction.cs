using Feminancials.Application.Common.Interfaces;
using Feminancials.Application.Common.Models;
using Feminancials.Application.Financials.Dtos;
using Microsoft.AspNetCore.Authorization;

namespace Feminancials.Application.Financials.Queries.GetExpenseByTransaction;

public record GetExpenseByTransactionQuery : IRequest<PaginatedList<ExpenseDto>>
{
    public int TransactionId { get; init; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetExpenseByTransactionQueryValidator : AbstractValidator<GetExpenseByTransactionQuery>
{
    public GetExpenseByTransactionQueryValidator()
    {
        RuleFor(x => x.TransactionId)
           .GreaterThanOrEqualTo(1).WithMessage("TransactionId at least greater than or equal to 1.");

        RuleFor(x => x.PageNumber)
            .GreaterThanOrEqualTo(1).WithMessage("PageNumber at least greater than or equal to 1.");

        RuleFor(x => x.PageSize)
            .GreaterThanOrEqualTo(1).WithMessage("PageSize at least greater than or equal to 1.");
    }
}

public class GetExpenseByTransactionQueryHandler : IRequestHandler<GetExpenseByTransactionQuery, PaginatedList<ExpenseDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly IAuthorizationService _authorizationService;
    private readonly IUser _user;

    public GetExpenseByTransactionQueryHandler(IApplicationDbContext context, IMapper mapper, IAuthorizationService authorizationService, IUser user)
    {
        _context = context;
        _mapper = mapper;
        _authorizationService = authorizationService;
        _user = user;
    }

    public async Task<PaginatedList<ExpenseDto>> Handle(GetExpenseByTransactionQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
