using Feminancials.Application.Collectives.Queries.GetCollectivesWithPagination;
using Feminancials.Application.Common.Models;
using Feminancials.Application.Financials.Dtos;
using Feminancials.Application.Financials.Queries.GetTransaction;
using Feminancials.Application.Financials.Queries.GetTransactionsWithPagination;
using Feminancials.Application.TodoItems.Queries.GetTodoItemsWithPagination;
using Feminancials.Application.TodoLists.Commands.CreateTodoList;
using Feminancials.Application.TodoLists.Commands.DeleteTodoList;
using Feminancials.Application.TodoLists.Commands.UpdateTodoList;
using Feminancials.Application.TodoLists.Queries.GetTodos;

namespace Feminancials.Web.Endpoints;

public class Collectives : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapGet(GetCollectives)
            .MapPost(CreateCollective)
            .MapPut(UpdateCollective, "{id}")
            .MapDelete(DeleteCollective, "{id}");
    }

    public Task<PaginatedList<CollectiveDto>> GetCollectives(ISender sender, [AsParameters] GetCollectives query)
    {
        return  sender.Send(query);
    }

    public Task<int> CreateCollective(ISender sender, CreateTodoListCommand command)
    {
        return sender.Send(command);
    }

    public async Task<IResult> UpdateCollective(ISender sender, int id, UpdateTodoListCommand command)
    {
        if (id != command.Id) return Results.BadRequest();
        await sender.Send(command);
        return Results.NoContent();
    }

    public async Task<IResult> DeleteCollective(ISender sender, int id)
    {
        await sender.Send(new DeleteTodoListCommand(id));
        return Results.NoContent();
    }
}
