using System;
using System.ComponentModel.DataAnnotations;
using Avia.Products;
using Volo.Abp.Application.Dtos;

namespace Avia.Sales;

public class SaleDto : AuditedEntityDto<Guid>
{
    public Guid ProductId { get; set; }
    public virtual ProductDto? Product { get; set; }
    public DateTime Date { get; set; }
    public string? Note { get; set; }
    public float Price { get; set; }
}