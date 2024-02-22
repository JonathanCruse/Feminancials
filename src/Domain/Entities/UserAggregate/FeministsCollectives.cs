using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Feminancials.Infrastructure.Identity;

namespace Feminancials.Domain.Entities.UserAggregate;
public class FeministsCollectives : BaseAuditableEntity
{
    public Feminist Feminist { get; set; } = null!;
    public Collective Collective { get; set; } = null!;
    public float CurrentDebt { get; set; }
}
