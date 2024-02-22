using Feminancials.Domain.Entities.FinancialsAggregate;

namespace Feminancials.Application.Financials.Dtos;

public class ExpenseDto
{
    private class Mapping : Profile
    {
        public int Id { get; init; }
        public float Amount { get; init; }
        public FeministDto Debtor { get; init; } = null!;
        public TransactionDto Transaction { get; init; } = null!;
        public Mapping()
        {
            CreateMap<Expense, ExpenseDto>();
        }
    }
}
