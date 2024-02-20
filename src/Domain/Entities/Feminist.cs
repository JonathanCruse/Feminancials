﻿using Feminancials.Domain.Entities.Aggregates.FinancialServer;
using Microsoft.AspNetCore.Identity;

namespace Feminancials.Infrastructure.Identity;

public class Feminist : IdentityUser
{
    public ICollection<Collective> Collectives { get; set; } = new List<Collective>();
    public ICollection<Expense> Expenses { get; set; } = new List<Expense>();

}
