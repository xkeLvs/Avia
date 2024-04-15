using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Avia.Commons;
using Avia.Products;
using Blazorise;
using Microsoft.AspNetCore.Components;
using Volo.Abp.Application.Dtos;

namespace Avia.Blazor.Pages.Product
{
    public partial class Index : ComponentBase
    {
        // Add your code here
        private List<ProductDto> Products { get; set; } = new();
        public required IProductAppService ProductAppService { get; set; } // Injected via DI
        public required ICategoryAppService CategoryAppService { get; set; } // Injected via DI
        private CreateUpdateProductDto createUpdateProductDto = new();
        private List<CategoryDto> Categories { get; set; } = new List<CategoryDto>();

        private Guid selectedProductId = Guid.Empty;

        private Modal addProductModal = new();

        private IEnumerable<DrinkSize> DrinkSizes = Enum.GetValues(typeof(DrinkSize))
            .Cast<DrinkSize>();
        private IEnumerable<Temperature> Temperatures = Enum.GetValues(typeof(Temperature))
            .Cast<Temperature>();

        [Inject]
        IMessageService MessageService { get; set; } = default!;
        protected override async Task OnInitializedAsync()
        {
            Products = await ProductAppService.GetAllProductListAsync();
            Categories = await CategoryAppService.GetAllCategoryListAsync();

            var values = Enum.GetValues(typeof(DrinkSize)).Cast<DrinkSize>();

            foreach (var enumValue in values)
            {
                Console.WriteLine(Enum.GetName(typeof(DrinkSize), enumValue));
            }

            Console.WriteLine(JsonSerializer.Serialize(values));
        }

        private async Task ShowModal()
        {
            // Handle edit logic here
            await addProductModal.Show();
            createUpdateProductDto.CategoryId = Categories.First().Id;
            createUpdateProductDto.DrinkSize = DrinkSizes.First();
            createUpdateProductDto.Temperature = Temperatures.First();

        }

        private async Task EditProduct(ProductDto product)
        {
            // Handle edit logic here
            await addProductModal.Show();

            createUpdateProductDto.Name = product.Name;
            createUpdateProductDto.Price = product.Price;
            createUpdateProductDto.CategoryId = product.CategoryId;
            createUpdateProductDto.DrinkSize = product.DrinkSize;
            createUpdateProductDto.Temperature = product.Temperature;
            selectedProductId = product.Id;
        }

        private async Task DeleteProduct(ProductDto product)
        {
            await ShowDeleteMessage(product.Id);
        }

        private async Task HandleValidSubmit()
        {
            Console.WriteLine(JsonSerializer.Serialize(createUpdateProductDto));

            if (selectedProductId != Guid.Empty)
                await ProductAppService.UpdateAsync(selectedProductId, createUpdateProductDto);
            else
                await ProductAppService.CreateAsync(createUpdateProductDto);

            Products = await ProductAppService.GetAllProductListAsync();
            createUpdateProductDto = new();
            selectedProductId = Guid.Empty;

            await addProductModal.Hide();
        }

        async Task ShowDeleteMessage(Guid productId)
        {
            if (await MessageService.Confirm("Are you sure you want to confirm?", "Confirmation"))
            {
                await ProductAppService.DeleteAsync(productId);
                Products = await ProductAppService.GetAllProductListAsync();
            }
        }
    }
}
