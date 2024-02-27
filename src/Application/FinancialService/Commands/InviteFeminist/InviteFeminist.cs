using Feminancials.Application.Common.Interfaces;

namespace Feminancials.Application.FinancialService.Commands.InviteFeminist;

public record InviteFeministCommand : IRequest<int>
{
}

public class InviteFeministCommandValidator : AbstractValidator<InviteFeministCommand>
{
    public InviteFeministCommandValidator()
    {
    }
}

public class InviteFeministCommandHandler : IRequestHandler<InviteFeministCommand, int>
{
    private readonly IApplicationDbContext _context;

    public InviteFeministCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(InviteFeministCommand request, CancellationToken cancellationToken)
    {
        await Task.Delay(1);
        throw new NotImplementedException();
    }
}
