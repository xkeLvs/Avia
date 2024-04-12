using System;
using System.ComponentModel.DataAnnotations;

namespace Avia.Products;

public class CreateUpdateProductDto
{
    [Required]
    public string Name { get; set; } = "";
    
    [Required]
    public Guid CategoryId { get; set; }

    [Required]
    public float Price { get; set; }
}