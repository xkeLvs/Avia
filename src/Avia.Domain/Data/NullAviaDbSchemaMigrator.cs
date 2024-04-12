using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Avia.Data;

/* This is used if database provider does't define
 * IAviaDbSchemaMigrator implementation.
 */
public class NullAviaDbSchemaMigrator : IAviaDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
