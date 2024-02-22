using Feminancials.Application.Common.Interfaces;
using Feminancials.Application.Financials.Dtos;
using Microsoft.AspNetCore.Authorization;

namespace Feminancials.Application.Financials.Queries.GetTransaction;

public record GetTransactionQuery : IRequest<TransactionExpandedDto>
{
    public int TransactionId { get; init; }
}

public class GetTransactionQueryValidator : AbstractValidator<GetTransactionQuery>
{
    public GetTransactionQueryValidator()
    {
    }
}

public class GetTransactionQueryHandler : IRequestHandler<GetTransactionQuery, TransactionExpandedDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly IAuthorizationService _authorizationService;
    private readonly IUser _user;

    public GetTransactionQueryHandler(IApplicationDbContext context, IMapper mapper, IAuthorizationService authorizationService, IUser user)
    {
        _context = context;
        _mapper = mapper;
        _authorizationService = authorizationService;
        _user = user;
    }

    public async Task<TransactionExpandedDto> Handle(GetTransactionQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
