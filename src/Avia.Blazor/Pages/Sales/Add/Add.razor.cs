using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Avia.Products;
using Avia.Sales;
using Blazorise;
using Microsoft.AspNetCore.Components;

namespace Avia.Blazor.Pages.Sales.Add
{
    public partial class Add : ComponentBase
    {
        // Add your code here
        private List<SaleDto> ListOfSales { get; set; } = new List<SaleDto>();
        public required ISaleAppService SaleAppService { get; set; } // Injected via DI
        public required IProductAppService ProductAppService { get; set; } // Injected via DI
        private CreateUpdateSaleDto createUpdateSaleDto = new();
        private List<CreateUpdateSaleDto> createUpdateSaleDtos = new();

        DatePicker<DateTime?>? datePicker;
        DateTime? dateValue = DateTime.Now;
        string? note = "";

        private List<ProductDto> Products { get; set; } = new();
        private List<ProductDto> filteredProducts { get; set; } = new();

        private Modal addSaleModal = new();

        [Inject]
        IMessageService MessageService { get; set; } = default!;

        [Inject] 
        NavigationManager? NavigationManager { get; set; } // Injected via DI


        int Quantity = 1;

        protected override async Task OnInitializedAsync()
        {
            ListOfSales = await SaleAppService.GetAllSaleListAsync();
            Products = await ProductAppService.GetAllProductListAsync();
            filteredProducts = Products;
            await ResetSale();
        }

        Task OnSearchProduct(string value)
        {
            Console.WriteLine(value);

            if (string.IsNullOrWhiteSpace(value))
            {
                filteredProducts = Products;
            }
            else
            {
                filteredProducts = Products.FindAll(p =>
                    p.Name.Contains(value, StringComparison.OrdinalIgnoreCase)
                );
            }

            createUpdateSaleDto.ProductId = filteredProducts[0].Id;
            createUpdateSaleDto.Date = dateValue ?? DateTime.Now;
            Console.WriteLine(JsonSerializer.Serialize(createUpdateSaleDto));

            return Task.CompletedTask;
        }

        Task AddSaleToSaleDtos()
        {
            createUpdateSaleDto.Date = dateValue ?? DateTime.Now;
            createUpdateSaleDto.Note = note;
            for (int i = 0; i < Quantity; i++)
            {
                createUpdateSaleDtos.AddFirst(createUpdateSaleDto);
            }
            Console.WriteLine(JsonSerializer.Serialize(createUpdateSaleDtos));

            // ResetSale();    
            createUpdateSaleDto = new();
            filteredProducts = Products;
            createUpdateSaleDto.ProductId = filteredProducts[0].Id;
            return Task.CompletedTask;
        }

        Task ResetSale()
        {
            createUpdateSaleDto = new();
            filteredProducts = Products;
            createUpdateSaleDto.ProductId = filteredProducts[0].Id;
            return Task.CompletedTask;
        }

        Task RemoveSale(CreateUpdateSaleDto sale)
        {
            // createUpdateSaleDtos.Remove(sale);

            createUpdateSaleDtos.Remove(sale);

            Console.WriteLine(JsonSerializer.Serialize(createUpdateSaleDtos));
            
            createUpdateSaleDto = new();
            filteredProducts = Products;
            createUpdateSaleDto.ProductId = filteredProducts[0].Id;
            
            return Task.CompletedTask;
        }

        private async Task HandleValidSubmit()
        {
            Console.WriteLine(JsonSerializer.Serialize(createUpdateSaleDto));

            await SaleAppService.AddSaleListAsync(createUpdateSaleDtos);

            NavigationManager?.NavigateTo("/sales");
        }

        async Task ShowDeleteMessage(Guid saleId)
        {
            if (await MessageService.Confirm("Are you sure you want to confirm?", "Confirmation"))
            {
                await SaleAppService.DeleteAsync(saleId);

                ListOfSales = await SaleAppService.GetAllSaleListAsync();
            }
        }
    }
}
