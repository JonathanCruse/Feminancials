using Feminancials.Application.Common.Interfaces;
using Feminancials.Application.Common.Mappings;
using Feminancials.Application.Common.Models;
using Feminancials.Application.Common.Security;
using Feminancials.Application.TodoItems.Queries.GetTodoItemsWithPagination;
using Feminancials.Domain.Constants;
using Microsoft.AspNetCore.Authorization;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Feminancials.Application.Financials.Queries.GetTransactionsWithPagination;


public record GetTransactionsWithPaginationQuery : IRequest<PaginatedList<TransaactionsVm>>
{
    public int CollectiveId { get; init; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetTransactionsWithPaginationQueryValidator : AbstractValidator<GetTransactionsWithPaginationQuery>
{
    public GetTransactionsWithPaginationQueryValidator()
    {
        RuleFor(x => x.CollectiveId)
            .GreaterThan(-1).WithMessage("Collective Id Invalid");
        
        RuleFor(x => x.PageNumber)
            .GreaterThanOrEqualTo(1).WithMessage("PageNumber at least greater than or equal to 1.");

        RuleFor(x => x.PageSize)
            .GreaterThanOrEqualTo(1).WithMessage("PageSize at least greater than or equal to 1.");
    }
}

public class GetTransactionsWithPaginationQueryHandler : IRequestHandler<GetTransactionsWithPaginationQuery, PaginatedList<TransaactionsVm>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly IAuthorizationService _authorizationService;
    private readonly IUser _user;
    public GetTransactionsWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper, IAuthorizationService authorizationService, IUser user)
    {
        _context = context;
        _mapper = mapper;
        _authorizationService = authorizationService;
        _user = user;
    }

    public async Task<PaginatedList<TransaactionsVm>> Handle(GetTransactionsWithPaginationQuery request, CancellationToken cancellationToken)
    {
        Guard.Against.Null(_user.ClaimsPrincipal);
        var collective = _context.Collectives.Where(x => x.Id == request.CollectiveId).AsNoTracking().FirstOrDefault();
        Guard.Against.Null(collective);
        if (_authorizationService.AuthorizeAsync(_user.ClaimsPrincipal!, collective, Policies.CanAccessCollective).IsCompletedSuccessfully)

            return await _context.Transactions
            .Where(x => x.Debtor.Id == request.CollectiveId)
            .ProjectTo<TransaactionsVm>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
        else throw new UnauthorizedAccessException();
    }
}
