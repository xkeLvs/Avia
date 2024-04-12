using System;
using System.ComponentModel.DataAnnotations;

namespace Avia.Products;

public class CreateUpdateCategoryDto
{
    [Required]
    public string Name { get; set; } = "";
}