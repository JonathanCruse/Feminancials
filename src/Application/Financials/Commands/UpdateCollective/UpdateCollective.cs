using Feminancials.Application.Common.Interfaces;

namespace Feminancials.Application.Financials.Commands.UpdateCollective;

public record UpdateCollectiveCommand : IRequest<int>
{
    public string? Name { get; set; }
    public string? Desription { get; set; }
}

public class UpdateCollectiveCommandValidator : AbstractValidator<UpdateCollectiveCommand>
{
    public UpdateCollectiveCommandValidator()
    {
        RuleFor(v => v.Name)
            .MaximumLength(100);
        RuleFor(v => v.Desription).MaximumLength(400);
    }
}

public class UpdateCollectiveCommandHandler : IRequestHandler<UpdateCollectiveCommand, int>
{
    private readonly IApplicationDbContext _context;

    public UpdateCollectiveCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(UpdateCollectiveCommand request, CancellationToken cancellationToken)
    {
        await Task.Delay(1);

        throw new NotImplementedException();
    }
}
