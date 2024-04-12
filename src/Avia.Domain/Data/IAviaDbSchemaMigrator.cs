using System.Threading.Tasks;

namespace Avia.Data;

public interface IAviaDbSchemaMigrator
{
    Task MigrateAsync();
}
