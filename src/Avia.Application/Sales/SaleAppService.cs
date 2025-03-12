using System;
using System.Collections.Generic;
using System.Diagnostics; // Add the missing using statement for LINQ operations
using System.Linq;
using System.Threading.Tasks;
using Avia.Products;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;

namespace Avia.Sales;

public class SaleAppService
    : CrudAppService<Sale, SaleDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateSaleDto>,
        ISaleAppService
{
    private readonly IRepository<Product, Guid> _productRepository;

    public SaleAppService(
        IRepository<Product, Guid> productRepository,
        IRepository<Sale, Guid> repository
    )
        : base(repository)
    {
        _productRepository = productRepository;
    }

    public async Task<List<SaleDto>> GetAllSaleListAsync()
    {
        //Get the IQueryable<Book> from the repository
        var queryable = await Repository.GetQueryableAsync();

        //Prepare a query to join books and authors

        var query =
            from sale in queryable
            join product in await _productRepository.GetQueryableAsync()
                on sale.ProductId equals product.Id
            select new { sale, product };

        //Execute the query and get a list
        var queryResult = await AsyncExecuter.ToListAsync(query);

        //Convert the query result to a list of BookDto objects
        return queryResult
            .Select(x =>
            {
                var saleDto = ObjectMapper.Map<Sale, SaleDto>(x.sale);
                saleDto.Product = ObjectMapper.Map<Product, ProductDto>(x.product);
                return saleDto;
            })
            .ToList();
    }

    public async Task<List<SaleDto>> AddSaleListAsync(List<CreateUpdateSaleDto> sales)
    {
        foreach (var sale in sales)
        {
            await Repository.InsertAsync(ObjectMapper.Map<CreateUpdateSaleDto, Sale>(sale));
        }
        return await GetAllSaleListAsync();
    }
}
