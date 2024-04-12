using Avia.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Avia.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(AviaEntityFrameworkCoreModule),
    typeof(AviaApplicationContractsModule)
    )]
public class AviaDbMigratorModule : AbpModule
{
}
