using Feminancials.Application.Collectives.Queries.GetCollectivesWithPagination;
using Feminancials.Application.Common.Interfaces;
using Feminancials.Application.Common.Models;
using Microsoft.AspNetCore.Authorization;

namespace Feminancials.Application.Financials.Queries.GetCollectives;

public record GetCollectivesQuery : IRequest<PaginatedList<CollectiveDto>>
{
    public string FeministId { get; init; } = null!;
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetCollectivesQueryValidator : AbstractValidator<GetCollectivesQuery>
{
    public GetCollectivesQueryValidator()
    {
        RuleFor(x => x.FeministId)
            .NotNull().WithMessage("Feminist Id Invalid")
            .NotEmpty().WithMessage("Feminist Id is empty");

        RuleFor(x => x.PageNumber)
            .GreaterThanOrEqualTo(1).WithMessage("PageNumber at least greater than or equal to 1.");

        RuleFor(x => x.PageSize)
            .GreaterThanOrEqualTo(1).WithMessage("PageSize at least greater than or equal to 1.");
    }
}

public class GetCollectivesQueryHandler : IRequestHandler<GetCollectivesQuery, PaginatedList<CollectiveDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly IAuthorizationService _authorizationService;
    private readonly IUser _user;

    public GetCollectivesQueryHandler(IApplicationDbContext context, IMapper mapper, IAuthorizationService authorizationService, IUser user)
    {
        _context = context;
        _mapper = mapper;
        _authorizationService = authorizationService;
        _user = user;
    }

    public async Task<PaginatedList<CollectiveDto>> Handle(GetCollectivesQuery request, CancellationToken cancellationToken)
    {
        await Task.Delay(1);

        var collective = _context.Collectives
            .Include(x => x.Collaborators)
            .Where(x => x.Collaborators.Any(y => y.FeministId == request.FeministId));
        throw new NotImplementedException();
    }
}
