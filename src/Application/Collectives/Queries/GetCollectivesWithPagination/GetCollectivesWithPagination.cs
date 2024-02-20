using System.Security.Cryptography.X509Certificates;
using Feminancials.Application.Common.Interfaces;
using Feminancials.Application.Common.Mappings;
using Feminancials.Application.Common.Models;
using Feminancials.Application.TodoItems.Queries.GetTodoItemsWithPagination;

namespace Feminancials.Application.Collectives.Queries.GetCollectivesWithPagination;

public record GetCollectivesWithPaginationQuery : IRequest<PaginatedList<CollectiveDto>>
{
    public string FeministId { get; init; } = null!;
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetCollectivesWithPaginationQueryValidator : AbstractValidator<GetCollectivesWithPaginationQuery>
{
    public GetCollectivesWithPaginationQueryValidator()
    {
        RuleFor(x => x.FeministId)
            .NotEmpty().WithMessage("Feminist must be specified");

        RuleFor(x => x.PageNumber)
            .GreaterThanOrEqualTo(1).WithMessage("PageNumber at least greater than or equal to 1.");

        RuleFor(x => x.PageSize)
            .GreaterThanOrEqualTo(1).WithMessage("PageSize at least greater than or equal to 1.");
    }
}

public class GetCollectivesWithPaginationQueryHandler : IRequestHandler<GetCollectivesWithPaginationQuery, PaginatedList<CollectiveDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetCollectivesWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<CollectiveDto>> Handle(GetCollectivesWithPaginationQuery request, CancellationToken cancellationToken)
    {
        var feminist = _context.Feminists.First(x => x.Id == request.FeministId);
        Guard.Against.Null(feminist);

        return await _context.Collectives.Where(x => x.Collaborators.Any(y => y.Id == feminist.Id))
            .OrderBy(x => x.Created)
            .ProjectTo<CollectiveDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
