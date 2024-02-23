using Feminancials.Application.Common.Interfaces;
using Feminancials.Application.Common.Models;
using Feminancials.Application.Financials.Dtos;
using Microsoft.AspNetCore.Authorization;

namespace Feminancials.Application.Financials.Queries.GetExpenses;

public record GetExpensesByFeministQuery : IRequest<PaginatedList<ExpenseDto>>
{
    public string FeministId { get; init; } = null!;
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetExpensesQueryValidator : AbstractValidator<GetExpensesByFeministQuery>
{
    public GetExpensesQueryValidator()
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

public class GetExpensesByFeministQueryHandler : IRequestHandler<GetExpensesByFeministQuery, PaginatedList<ExpenseDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly IAuthorizationService _authorizationService;
    private readonly IUser _user;

    public GetExpensesByFeministQueryHandler(IApplicationDbContext context, IMapper mapper, IAuthorizationService authorizationService, IUser user)
    {
        _context = context;
        _mapper = mapper;
        _authorizationService = authorizationService;
        _user = user;
    }

    public async Task<PaginatedList<ExpenseDto>> Handle(GetExpensesByFeministQuery request, CancellationToken cancellationToken)
    {
        await Task.Delay(1);
        throw new NotImplementedException();
    }
}
