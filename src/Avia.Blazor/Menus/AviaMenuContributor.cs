using System.Threading.Tasks;
using Avia.Localization;
using Avia.MultiTenancy;
using Volo.Abp.Identity.Blazor;
using Volo.Abp.SettingManagement.Blazor.Menus;
using Volo.Abp.TenantManagement.Blazor.Navigation;
using Volo.Abp.UI.Navigation;

namespace Avia.Blazor.Menus;

public class AviaMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var administration = context.Menu.GetAdministration();
        var l = context.GetLocalizer<AviaResource>();

        context.Menu.Items.Insert(
            0,
            new ApplicationMenuItem(
                AviaMenus.Home,
                l["Menu:Home"],
                "/",
                icon: "fas fa-home",
                order: 0
            )
        );

        context.Menu.Items.InsertRange(
            1,
            new[]
            {
                new ApplicationMenuItem(
                    AviaMenus.Sales,
                    l["Sales"],
                    "/sales",
                    icon: "fas fa-shopping-cart",
                    order: 1
                ),
                new ApplicationMenuItem(
                    AviaMenus.Inventory,
                    l["Inventory"],
                    "/inventory",
                    icon: "fas fa-boxes",
                    order: 2
                ),
                new ApplicationMenuItem(
                    AviaMenus.Products,
                    l["Products"],
                    "/products",
                    icon: "fas fa-cube",
                    order: 3
                )
            }
        );

        if (MultiTenancyConsts.IsEnabled)
        {
            administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
        }
        else
        {
            // administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
        }

        administration.SetSubItemOrder(IdentityMenuNames.GroupName, 2);
        administration.SetSubItemOrder(SettingManagementMenus.GroupName, 3);

        return Task.CompletedTask;
    }
}
