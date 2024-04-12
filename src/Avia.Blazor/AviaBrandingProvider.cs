using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Avia.Blazor;

[Dependency(ReplaceServices = true)]
public class AviaBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Avia";
}
