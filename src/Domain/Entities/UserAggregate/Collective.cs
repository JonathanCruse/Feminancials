﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Feminancials.Infrastructure.Identity;

namespace Feminancials.Domain.Entities.UserAggregate;
public class Collective : BaseAuditableEntity
{
    public ICollection<Feminist> Collaborators { get; set; } = new List<Feminist>();
    [MaxLength(100)]
    public string Name { get; set; } = null!;
    [MaxLength(400)]
    public string? Description { get; set; }
    public IEnumerable<(Feminist feminist, float scale)> GetWeightedCollaborators ()
    {
        var sum = Collaborators.Sum(x => x.MonthlyIncome);
        return Collaborators.Select(x => (x, x.MonthlyIncome / Collaborators.Sum(x => x.MonthlyIncome)));
    } 
}