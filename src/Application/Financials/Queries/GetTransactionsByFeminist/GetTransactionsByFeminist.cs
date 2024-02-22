using Feminancials.Application.Common.Interfaces;
using Feminancials.Application.Common.Models;
using Feminancials.Application.Financials.Dtos;
using Microsoft.AspNetCore.Authorization;

namespace Feminancials.Application.Financials.Queries.GetTransactionsByFeminist;

public record GetTransactionsByFeministQuery : IRequest<PaginatedList<TransactionDto>>
{
    public string FeministId { get; init; } = null!;
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetTransactionsByFeministQueryValidator : AbstractValidator<GetTransactionsByFeministQuery>
{
    public GetTransactionsByFeministQueryValidator()
    {
    }
}

public class GetTransactionsByFeministQueryHandler : IRequestHandler<GetTransactionsByFeministQuery, PaginatedList<TransactionDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly IAuthorizationService _authorizationService;
    private readonly IUser _user;

    public GetTransactionsByFeministQueryHandler(IApplicationDbContext context, IMapper mapper, IAuthorizationService authorizationService, IUser user)
    {
        _context = context;
        _mapper = mapper;
        _authorizationService = authorizationService;
        _user = user;
    }

    public async Task<PaginatedList<TransactionDto>> Handle(GetTransactionsByFeministQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
