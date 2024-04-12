using Volo.Abp.Modularity;

namespace Avia;

[DependsOn(
    typeof(AviaDomainModule),
    typeof(AviaTestBaseModule)
)]
public class AviaDomainTestModule : AbpModule
{

}
