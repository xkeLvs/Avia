using System;
using System.ComponentModel.DataAnnotations;
using Avia.Products;

namespace Avia.Sales;

public class CreateUpdateSaleDto
{
    [Required]
    public Guid ProductId { get; set; }
    public DateTime Date { get; set; }
    public string? Note { get; set; }
}