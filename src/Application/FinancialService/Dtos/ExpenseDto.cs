using Feminancial.Domain.Entities;
namespace Feminancials.Application.FinancialService.Dtos;

public class ExpenseDto
{
    public int Id { get; set; }
    public FeministDto Debtor{ get; set; } = new FeministDto();
    public float Amount { get; set; }
    public TransactionDto Transaction { get; set; } = new TransactionDto();
    public CollectiveDto Creditor { get; set; } = new CollectiveDto();
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Expense, ExpenseDto>();
        }
    }
}
