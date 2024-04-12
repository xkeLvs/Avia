using Avia.Localization;
using Volo.Abp.AspNetCore.Components;

namespace Avia.Blazor;

public abstract class AviaComponentBase : AbpComponentBase
{
    protected AviaComponentBase()
    {
        LocalizationResource = typeof(AviaResource);
    }
}
