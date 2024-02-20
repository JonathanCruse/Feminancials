using System.Transactions;

namespace Feminancials.Application.Financials.Queries.GetTransactionsWithPagination;

public class TransaactionsVm
{
    public required IReadOnlyCollection<TransactionDto> Transactions { get; set; }
}
