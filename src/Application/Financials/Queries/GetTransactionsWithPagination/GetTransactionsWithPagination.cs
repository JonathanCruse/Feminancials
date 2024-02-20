using Feminancials.Application.Common.Interfaces;
using Feminancials.Application.Common.Mappings;
using Feminancials.Application.Common.Models;
using Feminancials.Application.TodoItems.Queries.GetTodoItemsWithPagination;

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
    public GetTransactionsWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<TransaactionsVm>> Handle(GetTransactionsWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _context.Transactions
            .Where(x => x.Debtor.Id == request.CollectiveId)
            .ProjectTo<TransaactionsVm>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
