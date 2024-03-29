﻿using Feminancials.Application.Common.Interfaces;
using Feminancials.Application.Common.Models;

namespace Feminancials.Application.FinancialService.Queries.GetBalanceForFeminist;

public record GetBalanceForFeministQuery : IRequest<float>
{
}

public class GetBalanceForFeministQueryValidator : AbstractValidator<GetBalanceForFeministQuery>
{
    public GetBalanceForFeministQueryValidator()
    {
    }
}

public class GetBalanceForFeministQueryHandler : IRequestHandler<GetBalanceForFeministQuery, float>
{
    private readonly IApplicationDbContext _context;

    public GetBalanceForFeministQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<float> Handle(GetBalanceForFeministQuery request, CancellationToken cancellationToken)
    {
        await Task.Delay(1);
        throw new NotImplementedException();
    }
}
