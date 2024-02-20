using Feminancials.Domain.Entities.FinancialsAggregate;
using Feminancials.Domain.Entities.UserAggregate;
using Microsoft.AspNetCore.Identity;

namespace Feminancials.Infrastructure.Identity;

public class Feminist : IdentityUser
{
    public ICollection<Collective> Collectives { get; set; } = new List<Collective>();
    public ICollection<Expense> Expenses { get; set; } = new List<Expense>();
    public float MonthlyIncome { get; set; }
    public float CurrentDebt { get; set; }

}
