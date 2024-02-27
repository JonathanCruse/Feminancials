using Feminancials.Application.Common.Models;
using Feminancials.Application.FinancialService.Commands.CreateCollective;
using Feminancials.Application.FinancialService.Commands.DeleteCollective;
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

public class Collectives : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapGet(GetCollectives)
            .MapPost(CreateCollective)
            .MapDelete(DeleteCollective, "{id}");
    }

    public Task<PaginatedList<CollectiveDto>> GetCollectives(ISender sender, [AsParameters] GetCollectivesForFeministQuery query)
    {
        return sender.Send(query);
    }
    public Task<int> CreateCollective(ISender sender, CreateCollectiveCommand command)
    {
        return sender.Send(command);
    }
    public Task DeleteCollective(ISender sender, DeleteCollectiveCommand command)
    {
        return sender.Send(command);
    }

}
