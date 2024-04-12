using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;

namespace Avia.Products;

public class CategoryDto : AuditedEntityDto<Guid>
{
    public string Name { get; set; } = "";
}
