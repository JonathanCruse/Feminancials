using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Feminancials.Domain.Entities.UserAggregate;
using Feminancials.Infrastructure.Identity;

namespace Feminancials.Domain.Entities.FinancialsAggregate;
public class Transaction : BaseAuditableEntity
{
    public Feminist Creditor { get; set; } = null!;
    public Collective Debtor { get; set; } = null!;
    public ICollection<Expense> Expenses { get; set; } = new List<Expense>();
    public float Amount { get; set; }
    public void PublishTransaction()
    {
        AddDomainEvent(new TransactionCreatedEvent(this));
    }
}
