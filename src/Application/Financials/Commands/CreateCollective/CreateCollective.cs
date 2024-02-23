using Feminancials.Application.Common.Interfaces;

namespace Feminancials.Application.Financials.Commands.CreateCollective;

public record CreateCollectiveCommand : IRequest<int>
{
    public string Name { get; set; } = null!;
    public string? Desription { get; set; }
}

public class CreateCollectiveCommandValidator : AbstractValidator<CreateCollectiveCommand>
{
    public CreateCollectiveCommandValidator()
    {
        RuleFor(v => v.Name)
            .MaximumLength(100)
            .NotEmpty();
        RuleFor(v => v.Desription).MaximumLength(400);
    }
}

public class CreateCollectiveCommandHandler : IRequestHandler<CreateCollectiveCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateCollectiveCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateCollectiveCommand request, CancellationToken cancellationToken)
    {
        await Task.Delay(1);
        throw new NotImplementedException();
    }
}
