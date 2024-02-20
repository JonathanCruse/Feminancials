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
    public float Amount { get; set; }
    public required Transaction Transaction;
    
    public bool IsDeleted { get; set; }

}
