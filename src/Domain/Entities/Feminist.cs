using Feminancial.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Feminancials.Domain.Entities;

public class Feminist : IdentityUser
{
    public float? MonthlyIncome { get; set; }
    public virtual ICollection<FeministCollective> FeministCollectives { get; set; } = new List<FeministCollective>();

}
