using Feminancials.Application.Common.Interfaces;
using Feminancials.Application.Financials.Dtos;
using Microsoft.AspNetCore.Authorization;

namespace Feminancials.Application.Financials.Queries.GetCollectiveDetails;

public record GetCollectiveDetailsQuery : IRequest<CollectiveExpandedDto>
{
    public int CollectiveId { get; init; }
}

public class GetCollectiveDetailsQueryValidator : AbstractValidator<GetCollectiveDetailsQuery>
{
    public GetCollectiveDetailsQueryValidator()
    {
        RuleFor(x => x.CollectiveId)
            .GreaterThan(-1).WithMessage("Collective Id Invalid");
    }
}

public class GetCollectiveDetailsQueryHandler : IRequestHandler<GetCollectiveDetailsQuery, CollectiveExpandedDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly IAuthorizationService _authorizationService;
    private readonly IUser _user;

    public GetCollectiveDetailsQueryHandler(IApplicationDbContext context, IMapper mapper, IAuthorizationService authorizationService, IUser user)
    {
        _context = context;
        _mapper = mapper;
        _authorizationService = authorizationService;
        _user = user;
    }

    public async Task<CollectiveExpandedDto> Handle(GetCollectiveDetailsQuery request, CancellationToken cancellationToken)
    {
        await Task.Delay(1);
        throw new NotImplementedException();
    }
}
