using Feminancials.Application.Common.Exceptions;
using Feminancials.Application.TodoItems.Commands.CreateTodoItem;
using Feminancials.Application.TodoLists.Commands.CreateTodoList;
using Feminancials.Domain.Entities;

namespace Feminancials.Application.FunctionalTests.TodoItems.Commands;

using static Testing;

public class TransactionsCreatedEventHandlerTests : BaseTestFixture
{
    [Test]
    public async Task ShouldCreateNAmountOfExpenses()
    {

        var command = new CreateTodoItemCommand();

        await FluentActions.Invoking(() =>
            SendAsync(command)).Should().ThrowAsync<ValidationException>();
    }

}
