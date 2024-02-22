using Feminancials.Domain.Entities.UserAggregate;
using Feminancials.Infrastructure.Identity;

namespace Feminancials.Application.Financials.Dtos;

public class FeministDto
{
    private class Mapping : Profile
    {
        public required string Id { get; init; }
        public required string FullName { get; init; }
        public required string ProfilePicture { get; init; }

        public Mapping()
        {
            CreateMap<Feminist, FeministDto>();
        }
    }
}
