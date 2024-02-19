using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Feminancials.Infrastructure.Identity;

namespace Feminancials.Domain.Entities;
public class Expense : BaseAuditableEntity
{
    public int CreditorId { get; set; }
    public int DebtorId { get; set; }
    public Feminist Creditor { get; set; } = new Feminist();
    public Feminist Debtor { get; set; } = new Feminist();
    public float Amount { get; set; }
    public Transaction Transaction = new Transaction();

}
