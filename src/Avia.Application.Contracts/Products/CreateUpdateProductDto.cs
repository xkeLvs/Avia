using System;
using System.ComponentModel.DataAnnotations;
using Avia.Commons;

namespace Avia.Products;

public class CreateUpdateProductDto
{
    [Required]
    public string Name { get; set; } = "";
    
    [Required]
    public Guid CategoryId { get; set; }

    [Required]
    public float Price { get; set; }

    public DrinkSize? DrinkSize { get; set; }
    public Temperature? Temperature { get; set; }
}