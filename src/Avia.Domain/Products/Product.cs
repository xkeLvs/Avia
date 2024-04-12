using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Avia.Products;
public class Product : AuditedAggregateRoot<Guid>
{
    [Required]
    public required string Name { get; set; }

    [Required]
    public required Guid CategoryId { get; set; }
    public virtual Category Category { get; set; }

    [Required]
    public required float Price { get; set; }

}
