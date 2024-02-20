using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Feminancials.Infrastructure.Identity;

namespace Feminancials.Domain.Entities.Aggregates.FinancialServer;
public class Transaction : BaseAuditableEntity
{
    public Feminist Debtor { get; set; } = null!;
    public Collective Creditor { get; set; } = null!;
    public ICollection<Expense> Expenses { get; set; } = new List<Expense>();
    public float Amount { get; set; }

}
