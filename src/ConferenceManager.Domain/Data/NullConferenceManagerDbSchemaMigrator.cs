using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace ConferenceManager.Data;

/* This is used if database provider does't define
 * IConferenceManagerDbSchemaMigrator implementation.
 */
public class NullConferenceManagerDbSchemaMigrator : IConferenceManagerDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
