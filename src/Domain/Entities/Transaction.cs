using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Feminancials.Infrastructure.Identity;

namespace Feminancials.Domain.Entities;
public class Transaction : BaseAuditableEntity
{
    public int CreditorId { get; set; }
    public int DebtorId { get; set; }
    public Feminist Creditor { get; set; } = null!;
    public Collective Debtor { get; set; } = null!;
    public ICollection<Expense> Expenses { get; set; } = new List<Expense>();
    public float Amount { get; set; }

}
