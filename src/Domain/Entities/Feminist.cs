using Microsoft.AspNetCore.Identity;

namespace Feminancials.Infrastructure.Identity;

public class Feminist : IdentityUser
{
    public ICollection<Collective> Collectives { get; set; } = new List<Collective>();

}
