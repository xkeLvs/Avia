
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Avia.Products;

public class Category : AuditedAggregateRoot<Guid>
{
    public required string Name { get; set; }
    public ICollection<Product>? Products { get; set; }
}
