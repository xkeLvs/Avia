using System;
using Avia.Products;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

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
}
