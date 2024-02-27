using Microsoft.AspNetCore.Identity;

namespace Feminancials.Domain.Entities;

public class Feminist : IdentityUser
{
    public float? MonthlyIncome { get; set; }

}
