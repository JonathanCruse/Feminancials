﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feminancial.Domain.Entities;
public class Expense : BaseAuditableEntity
{
    public float Amount { get; set; }
    public virtual Feminist Debtor { get; set; } = null!;
    public virtual Collective Creditor { get; set; } = null!;
}
