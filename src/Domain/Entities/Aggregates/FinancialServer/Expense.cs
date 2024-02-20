using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Feminancials.Infrastructure.Identity;

namespace Feminancials.Domain.Entities.Aggregates.FinancialServer;
public class Expense : BaseAuditableEntity
{
    public Feminist Debtor { get; set; } = new Feminist();
    public float Amount { get; set; }
    public Transaction Transaction = new Transaction();

}
