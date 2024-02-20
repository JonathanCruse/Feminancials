using Feminancials.Application.Financials.Queries.GetTransactionsWithPagination;
using Feminancials.Application.TodoLists.Queries.GetTodos;
using Feminancials.Domain.Entities;
using Feminancials.Domain.Entities.UserAggregate;
using Feminancials.Infrastructure.Identity;

namespace Feminancials.Application.Collectives.Queries.GetCollectivesWithPagination;

public class CollectiveDto
{
    public int Id { get; init; }
    public required string Name { get; set; }
    public IReadOnlyCollection<FeministDto> Collaborators { get; set; } = new List<FeministDto>();
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Collective, CollectiveDto>();
        }
    }
}
