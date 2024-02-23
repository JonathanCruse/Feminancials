using Feminancials.Application.Common.Interfaces;
using Feminancials.Application.Common.Mappings;
using Feminancials.Application.Common.Models;
using Feminancials.Application.Common.Security;
using Feminancials.Application.Financials.Dtos;
using Feminancials.Application.TodoItems.Queries.GetTodoItemsWithPagination;
using Feminancials.Domain.Constants;
using Feminancials.Domain.Entities.UserAggregate;
using Microsoft.AspNetCore.Authorization;

namespace Feminancials.Application.Financials.Queries.GetTransactionsWithPagination;


public record GetTransactionsByCollectiveQuery : IRequest<PaginatedList<TransactionDto>>
{
    public int CollectiveId { get; init; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetTransactionsByCollectiveQueryValidator : AbstractValidator<GetTransactionsByCollectiveQuery>
{
    public GetTransactionsByCollectiveQueryValidator()
    {
        RuleFor(x => x.CollectiveId)
            .GreaterThan(-1).WithMessage("Collective Id Invalid");
        
        RuleFor(x => x.PageNumber)
            .GreaterThanOrEqualTo(1).WithMessage("PageNumber at least greater than or equal to 1.");

        RuleFor(x => x.PageSize)
            .GreaterThanOrEqualTo(1).WithMessage("PageSize at least greater than or equal to 1.");
    }
}

public class GetTransactionsByCollectiveQueryHandler : IRequestHandler<GetTransactionsByCollectiveQuery, PaginatedList<TransactionDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly IAuthorizationService _authorizationService;
    private readonly IUser _user;
    public GetTransactionsByCollectiveQueryHandler(IApplicationDbContext context, IMapper mapper, IAuthorizationService authorizationService, IUser user)
    {
        _context = context;
        _mapper = mapper;
        _authorizationService = authorizationService;
        _user = user;
    }

    public async Task<PaginatedList<TransactionDto>> Handle(GetTransactionsByCollectiveQuery request, CancellationToken cancellationToken)
    {
        Guard.Against.Null(_user.ClaimsPrincipal);
        Guard.Against.Null(_user.Id);


        var collective = _context.Collectives.Where(x => x.Id == request.CollectiveId).AsNoTracking().FirstOrDefault();
        Guard.Against.Null(collective);

        if (_authorizationService.AuthorizeAsync(_user.ClaimsPrincipal!, collective, Policies.CanAccessCollective).IsCompletedSuccessfully)

            return await _context.Transactions
            .Where(x => x.Debtor.Id == request.CollectiveId)
            .ProjectTo<TransactionDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
        else throw new UnauthorizedAccessException();
    }
}
