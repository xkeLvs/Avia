using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Avia.Products;
using Avia.Sales;
using Blazorise;
using Microsoft.AspNetCore.Components;

namespace Avia.Blazor.Pages.Sales
{
    public partial class Sales : ComponentBase
    {
        // Add your code here
        private List<SaleDto> ListOfSales { get; set; } = new List<SaleDto>();
        private List<SaleDto> FilteredSales { get; set; } = new List<SaleDto>();
        public required ISaleAppService SaleAppService { get; set; } // Injected via DI

        [Inject]
        IMessageService MessageService { get; set; } = default!;
        [Inject] 
        NavigationManager? NavigationManager { get; set; } // Injected via DI

        DatePicker<DateTime?>? datePicker;
        DateTime? dateValue;

        protected override async Task OnInitializedAsync()
        {
            ListOfSales = await SaleAppService.GetAllSaleListAsync();
            FilteredSales = ListOfSales;
        }

        private async Task DeleteSale(SaleDto sale)
        {
            // Handle delete logic here
            await SaleAppService.DeleteAsync(sale.Id);
            ListOfSales = new();
            ListOfSales = await SaleAppService.GetAllSaleListAsync();
            FilteredSales = ListOfSales;
        }

        void MethodToTriggerUrl()
        {
            NavigationManager?.NavigateTo("/sales/add");
        }

        private void FilterSalesByDate()
        {
            if(DateTime.TryParse(dateValue.ToString(), out DateTime date)){
                FilteredSales = ListOfSales.FindAll(s => s.Date.Date == date.Date);
            }else {
                FilteredSales = ListOfSales;
            }
        }
    }
}
