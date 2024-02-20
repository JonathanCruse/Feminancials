using Feminancials.Application.Collectives.Queries.GetCollectivesWithPagination;
using Feminancials.Application.TodoLists.Queries.GetTodos;
using Feminancials.Domain.Entities;
using Feminancials.Domain.Entities.FinancialsAggregate;
using Feminancials.Infrastructure.Identity;

namespace Feminancials.Application.Financials.Queries.GetTransactionsWithPagination;

public class TransactionDto
{
    public int Id { get; init; }
    public required string Description { get; init; }
    public float Amount { get; init; }
    public required CollectiveDto Collective { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Transaction, TransactionDto>();
        }
    }
}
