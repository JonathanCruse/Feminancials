using Feminancials.Application.Common.Interfaces;
using Feminancials.Application.Common.Mappings;
using Feminancials.Application.Common.Models;
using Feminancials.Application.Financials.Dtos;
using Feminancials.Domain.Constants;
using Feminancials.Infrastructure.Identity;
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
        RuleFor(x => x.FeministId).NotNull().NotEmpty().WithMessage("Invalid Feminist ID");
        RuleFor(x => x.PageNumber)
           .GreaterThanOrEqualTo(1).WithMessage("PageNumber at least greater than or equal to 1.");

        RuleFor(x => x.PageSize)
            .GreaterThanOrEqualTo(1).WithMessage("PageSize at least greater than or equal to 1.");
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
        Guard.Against.Null(_user.ClaimsPrincipal);
        Guard.Against.Null(_user.Id);

        Feminist? requestedFeminist = _context.Feminists.Where(x => x.Id ==  request.FeministId).FirstOrDefault();
        Guard.Against.Null(requestedFeminist);


        var Transactions = _context.Expenses
            .Include(x => x.Transaction)
            .Where(x => x.DebtorId == _user.Id)
            .AsNoTracking()
            .Select(x => x.Transaction);
        if (_authorizationService.AuthorizeAsync(_user.ClaimsPrincipal!, requestedFeminist!, Policies.CanAccessCollective).IsCompletedSuccessfully)

            return await Transactions
            .ProjectTo<TransactionDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
        else throw new UnauthorizedAccessException();
    }
}
