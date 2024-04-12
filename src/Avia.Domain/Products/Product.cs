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
    public Guid CategoryId { get; set; }
    public Category? Category { get; set; }

    [Required]
    public required float Price { get; set; }

}
