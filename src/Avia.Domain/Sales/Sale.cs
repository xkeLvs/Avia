
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;
using Avia.Products;
using System.ComponentModel.DataAnnotations;

namespace Avia.Sales;

public class Sale : AuditedAggregateRoot<Guid>
{
    [Required]
    public required Guid ProductId { get; set; }
    public virtual Product? Product { get; set; }
    public DateTime Date { get; set; }
    public string? Note { get; set; }
    public float Price { get; set; }

}
