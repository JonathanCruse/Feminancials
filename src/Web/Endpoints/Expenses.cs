using Feminancials.Application.Common.Models;
using Feminancials.Application.FinancialService.Commands.CreateEpenseForBalance;
using Feminancials.Application.FinancialService.Commands.CreateTransaction;
using Feminancials.Application.FinancialService.Commands.DeleteEpenseForBalance;
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

public class Expenses : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapGet(GetExpenses)
            .MapPost(CreateExpense)
            .MapDelete(DeleteExpense, "{id}");
            ;
    }

    public Task<PaginatedList<ExpenseDto>> GetExpenses(ISender sender, [AsParameters] GetExpensesForFeministQuery query)
    {
        return sender.Send(query);
    }

    public Task<int> CreateExpense(ISender sender, CreateEpenseForBalanceCommand command)
    {
        return sender.Send(command);
    }
    public async Task<IResult> DeleteExpense(ISender sender, int id)
    {
        await sender.Send(new DeleteEpenseForBalanceCommand(id));
        return Results.NoContent();
    }


}
