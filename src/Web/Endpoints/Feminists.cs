using Feminancials.Application.Common.Models;
using Feminancials.Application.FinancialService.Commands.CreateEpenseForBalance;
using Feminancials.Application.FinancialService.Commands.InviteFeminist;
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

public class Feminists : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapGet(GetFeminists)
            .MapPost(CreateFeminist)
            ;
    }

    public Task<PaginatedList<FeministDto>> GetFeminists(ISender sender, [AsParameters] GetFeministsForCollectiveQuery query)
    {
        return sender.Send(query);
    }

    public Task<int> CreateFeminist(ISender sender, InviteFeministCommand command)
    {
        return sender.Send(command);
    }

}
