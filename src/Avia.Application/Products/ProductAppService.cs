using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Avia.Products;

public class ProductAppService
    : CrudAppService<
        Product,
        ProductDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateUpdateProductDto
    >,
        IProductAppService
{
    private readonly IRepository<Category, Guid> _categoryRepository;

    public ProductAppService(
        IRepository<Category, Guid> categoryRepository,
        IRepository<Product, Guid> repository
    )
        : base(repository)
    {
        _categoryRepository = categoryRepository;
    }

    // public async Task<List<ProductDto>> GetAllProductListAsync()
    // {
    //     var dbSet = await GetDbSetAsync();
    //     var queryable = await Repository.WithDetailsAsync();
    //     var products = queryable.ToList();
    //     return new List<ProductDto>(ObjectMapper.Map<List<Product>, List<ProductDto>>(products));
    // }

    public async Task<List<ProductDto>> GetAllProductListAsync()
    {
        //Get the IQueryable<Book> from the repository
        var queryable = await Repository.GetQueryableAsync();

        //Prepare a query to join books and authors
        var query =
            from product in queryable
            join category in await _categoryRepository.GetQueryableAsync()
                on product.CategoryId equals category.Id
            select new { product, category };

        //Execute the query and get a list
        var queryResult = await AsyncExecuter.ToListAsync(query);

        //Convert the query result to a list of BookDto objects
        return queryResult
            .Select(x =>
            {
                var productDto = ObjectMapper.Map<Product, ProductDto>(x.product);
                productDto.Category = ObjectMapper.Map<Category, CategoryDto>(x.category);
                return productDto;
            })
            .ToList();
    }
}
