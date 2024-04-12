using Volo.Abp.Modularity;

namespace Avia;

public abstract class AviaApplicationTestBase<TStartupModule> : AviaTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
