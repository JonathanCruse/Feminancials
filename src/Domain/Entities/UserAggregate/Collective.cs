using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using Feminancials.Domain.Entities.FinancialsAggregate;
using Feminancials.Infrastructure.Identity;

namespace Feminancials.Domain.Entities.UserAggregate;
public class Collective : BaseAuditableEntity
{
    public ICollection<FeministsCollectives> Collaborators { get; set; } = new List<FeministsCollectives>();
    public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public IEnumerable<(FeministsCollectives feminist, float scale)> GetWeightedCollaborators()
    {
        var sum = Collaborators.Sum(x => x.Feminist.MonthlyIncome);
        return Collaborators.Select(x => (x, x.Feminist.MonthlyIncome / Collaborators.Sum(x => x.Feminist.MonthlyIncome)));
    }
}
