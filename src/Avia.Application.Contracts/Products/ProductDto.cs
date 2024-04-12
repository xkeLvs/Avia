using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;

namespace Avia.Products;

public class ProductDto : AuditedEntityDto<Guid>
{
    public string Name { get; set; } = "";
    public Guid CategoryId { get; set; }
    public CategoryDto? Category { get; set; }
    public float Price { get; set; }
}
