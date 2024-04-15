using AutoMapper;
using Avia.Products;

namespace Avia;

public class AviaApplicationAutoMapperProfile : Profile
{
    public AviaApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        // Product
        CreateMap<Product, ProductDto>();
        CreateMap<CreateUpdateProductDto, Product>();
        CreateMap<CreateUpdateProductDto, ProductDto>();

        // Product Category
        CreateMap<Category, CategoryDto>();
        CreateMap<CreateUpdateCategoryDto, Category>();
        CreateMap<CreateUpdateProductDto, CategoryDto>();

    }
}
