using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Avia.Sales;

public interface ISaleAppService :
    ICrudAppService<
        SaleDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateUpdateSaleDto>
{
    Task<List<SaleDto>> GetAllSaleListAsync();
    Task<List<SaleDto>> AddSaleListAsync(List<CreateUpdateSaleDto> sales);
}
