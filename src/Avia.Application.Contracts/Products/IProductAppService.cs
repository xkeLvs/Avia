using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Avia.Products;

public interface IProductAppService :
    ICrudAppService< 
        ProductDto,
        Guid, 
        PagedAndSortedResultRequestDto, 
        CreateUpdateProductDto> 
{
    Task<List<ProductDto>> GetAllProductListAsync();
}
