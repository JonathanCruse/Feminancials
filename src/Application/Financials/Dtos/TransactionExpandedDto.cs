using Feminancials.Application.Collectives.Queries.GetCollectivesWithPagination;

namespace Feminancials.Application.Financials.Dtos;

public class TransactionExpandedDto
{
    public int Id { get; init; }
    public required string Description { get; init; }
    public float Amount { get; init; }
    public required CollectiveDto Collective { get; init; }
    public required ICollection<ExpenseDto> Expenses { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<TransactionExpandedDto, TransactionDto>();
        }
    }
}
