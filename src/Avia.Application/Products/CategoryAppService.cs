using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Avia.Products;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;

namespace Avia.Products;

public class CategoryAppService :
    CrudAppService<
        Category,
        CategoryDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateUpdateCategoryDto>,
    ICategoryAppService
{
    public CategoryAppService(IRepository<Category, Guid> repository)
        : base(repository)
    {
    }

    
    public async Task<List<CategoryDto>> GetAllCategoryListAsync()
    {
        var categories = await Repository.GetListAsync();
        return new List<CategoryDto>(ObjectMapper.Map<List<Category>, List<CategoryDto>>(categories));
    }
}
