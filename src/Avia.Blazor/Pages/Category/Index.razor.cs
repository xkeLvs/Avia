using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Avia.Products;
using Blazorise;
using Microsoft.AspNetCore.Components;
using Volo.Abp.Application.Dtos;

namespace Avia.Blazor.Pages.Category
{
    public partial class Index : ComponentBase
    {
        // Add your code here
        private List<CategoryDto> Categories { get; set; } = new List<CategoryDto>();
        public required ICategoryAppService CategoryAppService { get; set; } // Injected via DI
        private CreateUpdateCategoryDto createUpdateCategoryDto = new();

        private Guid selectedCategoryId = Guid.Empty;

        private Modal addCategoryModal = new();

        [Inject]
        IMessageService MessageService { get; set; } = default!;

        protected override async Task OnInitializedAsync()
        {
            Categories = await CategoryAppService.GetAllCategoryListAsync();
        }

        private async Task EditCategory(CategoryDto category)
        {
            // Handle edit logic here
            await addCategoryModal.Show();

            createUpdateCategoryDto.Name = category.Name;
            selectedCategoryId = category.Id;
        }

        private async Task DeleteCategory(CategoryDto category)
        {
            await CategoryAppService.DeleteAsync(category.Id);
            Categories = new();
            Categories = await CategoryAppService.GetAllCategoryListAsync();
        }

        private async Task HandleValidSubmit()
        {
            Console.WriteLine(JsonSerializer.Serialize(createUpdateCategoryDto));

            if (selectedCategoryId != Guid.Empty)
                await CategoryAppService.UpdateAsync(selectedCategoryId, createUpdateCategoryDto);
            else
                await CategoryAppService.CreateAsync(createUpdateCategoryDto);

            Categories = await CategoryAppService.GetAllCategoryListAsync();
            createUpdateCategoryDto = new();
            selectedCategoryId = Guid.Empty;

            await addCategoryModal.Hide();
        }
    }
}
