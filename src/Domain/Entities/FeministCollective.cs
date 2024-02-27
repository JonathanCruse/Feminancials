using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feminancial.Domain.Entities;
public class FeministCollective : BaseAuditableEntity
{
    public virtual Collective Collective { get; set; } = null!;
    public virtual Feminist Feminist { get; set; } = null!;
    public float? CurrentBalance { get; set; }

}
