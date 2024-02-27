using Feminancials.Application.Common.Models;
using Feminancials.Application.FinancialService.Commands.CreateCollective;
using Feminancials.Application.FinancialService.Commands.CreateTransaction;
using Feminancials.Application.FinancialService.Commands.DeleteCollective;
using Feminancials.Application.FinancialService.Commands.DeleteTransaction;
using Feminancials.Application.FinancialService.Dtos;
using Feminancials.Application.FinancialService.Queries.GetBalanceForFeminist;
using Feminancials.Application.FinancialService.Queries.GetCollectivesForFeminist;
using Feminancials.Application.FinancialService.Queries.GetExpensesForFeminist;
using Feminancials.Application.FinancialService.Queries.GetFeministsForCollective;
using Feminancials.Application.FinancialService.Queries.GetTransactionForExpense;
using Feminancials.Application.FinancialService.Queries.GetTransactionsForCollective;
using Feminancials.Application.TodoItems.Commands.CreateTodoItem;
using Feminancials.Application.TodoItems.Commands.DeleteTodoItem;
using Feminancials.Application.TodoItems.Commands.UpdateTodoItem;
using Feminancials.Application.TodoItems.Commands.UpdateTodoItemDetail;
using Feminancials.Application.TodoItems.Queries.GetTodoItemsWithPagination;

namespace Feminancials.Web.Endpoints;

public class Transactions : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapGet(GetTransaction, "{id}")
            .MapGet(GetTransactions)
            .MapPost(CreateTransaction)
            .MapDelete(DeleteTransaction, "{id}");
    }

    public Task<PaginatedList<TransactionDto>> GetTransactions(ISender sender, [AsParameters] GetTransactionsForCollectiveQuery query)
    {
        return sender.Send(query);
    }
    public Task<TransactionDto> GetTransaction(ISender sender, int id)
    {
        return sender.Send(new GetTransactionForExpenseQuery(id));
    }

    public Task<int> CreateTransaction(ISender sender, CreateTransactionCommand command)
    {
        return sender.Send(command);
    }
    public async Task<IResult> DeleteTransaction(ISender sender, int id)
    {
        await sender.Send(new DeleteTransactionCommand (id));
        return Results.NoContent();
    }

}
