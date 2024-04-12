using Volo.Abp.Modularity;

namespace Avia;

[DependsOn(
    typeof(AviaApplicationModule),
    typeof(AviaDomainTestModule)
)]
public class AviaApplicationTestModule : AbpModule
{

}
