using System.Threading.Tasks;

namespace ConferenceManager.Data;

public interface IConferenceManagerDbSchemaMigrator
{
    Task MigrateAsync();
}
