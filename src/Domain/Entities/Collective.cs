using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feminancial.Domain.Entities;
public class Collective : BaseAuditableEntity
{
    public string Name { get; set; } = null!;

}
