using System;
using System.ComponentModel.DataAnnotations;
using Avia.Products;

namespace Avia.Sales;

public class CreateUpdateSaleDto
{
    public Guid Id { get; set; }
    [Required]
    public Guid ProductId { get; set; }
    public DateTime Date { get; set; }
    public string? Note { get; set; }
    public float Price { get; set; }


}