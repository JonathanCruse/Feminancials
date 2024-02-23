using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Feminancials.Infrastructure.Identity;

namespace Feminancials.Domain.Entities.FinancialsAggregate;
public class Expense : BaseAuditableEntity
{
    public Feminist Debtor { get; set; } = new Feminist();
    public string DebtorId { get; set; } = null!;
    public float Amount { get; set; }
    public Transaction Transaction { get; set; } = null!;
    public int TransactionId { get; set; }
    public bool IsDeleted { get; set; }

}
