using Feminancials.Domain.Entities.FinancialsAggregate;
using Feminancials.Domain.Entities.UserAggregate;
using Microsoft.AspNetCore.Identity;

namespace Feminancials.Infrastructure.Identity;

public class Feminist : IdentityUser
{
    public ICollection<FeministsCollectives> Collectives { get; set; } = new List<FeministsCollectives>();
    public ICollection<Expense> Expenses { get; set; } = new List<Expense>();
    public float MonthlyIncome { get; set; }

}
