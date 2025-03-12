using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Avia.Products;
using Volo.Abp.Domain.Entities.Auditing;

namespace Avia.Orders;

public class Order : AuditedAggregateRoot<Guid>
{
    public virtual Guid OrderId { get; protected set; }

    [Required]
    public required Guid ProductId { get; set; }
    public virtual Product? Product { get; set; }
}
