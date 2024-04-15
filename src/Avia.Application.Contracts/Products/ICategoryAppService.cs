using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Avia.Products;

public interface ICategoryAppService :
    ICrudAppService<
        CategoryDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateUpdateCategoryDto>
{
    Task<List<CategoryDto>> GetAllCategoryListAsync();
}
