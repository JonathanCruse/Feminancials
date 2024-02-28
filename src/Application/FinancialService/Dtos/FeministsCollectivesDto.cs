using Feminancial.Domain.Entities;
using Feminancials.Application.FinancialService.Commands.CreateCollective;
using Feminancials.Application.TodoLists.Queries.GetTodos;
using Feminancials.Domain.Entities;

namespace Feminancials.Application.FinancialService.Dtos;

public class FeministsCollectivesDto
{
    public float Balance { get; set; }
    public FeministDto Feminist { get; set; } = new FeministDto();
    public CollectiveDto Collective  { get; set; } = new CollectiveDto();
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<FeministCollective, FeministsCollectivesDto>();
        }
    }
}
