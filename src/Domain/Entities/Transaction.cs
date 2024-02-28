using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feminancial.Domain.Entities;
public class Transaction : BaseAuditableEntity
{
    public float Amount { get; set; }
    public string Description { get; set; } = String.Empty;
    public virtual Feminist Creditor { get; set; } = new Feminist();
    public virtual Collective Debtor { get; set; } = new Collective();
}
