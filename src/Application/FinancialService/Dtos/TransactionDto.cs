

using Feminancial.Domain.Entities;

namespace Feminancials.Application.FinancialService.Dtos;

public class TransactionDto
{
    public float Amount{ get; set; }
    public string Description { get; set; } = null!;
    public FeministDto Cretitor { get; set; } = new FeministDto();
    public CollectiveDto Debtor { get; set; } = new CollectiveDto();
    public IReadOnlyCollection<ExpenseDto> Expenses { get; set; } = new List<ExpenseDto>();
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Transaction, TransactionDto>();
        }
    }
}
