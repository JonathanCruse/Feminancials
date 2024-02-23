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
    public string CreditorId { get; set; } = null!;
    public Collective Debtor { get; set; } = null!;
    public int DebtorId { get; set; }
    public string Description { get; set; } = null!;
    public ICollection<Expense> Expenses { get; set; } = new List<Expense>();
    public float Amount { get; set; }
    private bool _isDeleted;
    public bool IsDeleted
    {
        get { return _isDeleted; }
        set
        {
            if (value)
            {
                DeleteTransaction();
                _isDeleted = false;
            }

        }
    }
    public void ActivateTransaction()
    {
        AddDomainEvent(new TransactionCreatedEvent(this));
    }
    private void DeleteTransaction()
    {
        AddDomainEvent(new TransactionDeletedEvent(this));
    }
}
