using Feminancials.Application.FinancialService.Dtos;
using Feminancials.Application.Common.Interfaces;
using Feminancials.Application.Common.Models;

namespace Feminancials.Application.FinancialService.Queries.GetFeministsForCollective;

public record GetFeministsForCollectiveQuery : IRequest<PaginatedList<FeministDto>>
{
}

public class GetFeministsForCollectiveQueryValidator : AbstractValidator<GetFeministsForCollectiveQuery>
{
    public GetFeministsForCollectiveQueryValidator()
    {
    }
}

public class GetFeministsForCollectiveQueryHandler : IRequestHandler<GetFeministsForCollectiveQuery, PaginatedList<FeministDto>>
{
    private readonly IApplicationDbContext _context;

    public GetFeministsForCollectiveQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<PaginatedList<FeministDto>> Handle(GetFeministsForCollectiveQuery request, CancellationToken cancellationToken)
    {
        await Task.Delay(1);
        throw new NotImplementedException();
    }
}
