using Volo.Abp.Modularity;

namespace Avia;

/* Inherit from this class for your domain layer tests. */
public abstract class AviaDomainTestBase<TStartupModule> : AviaTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
