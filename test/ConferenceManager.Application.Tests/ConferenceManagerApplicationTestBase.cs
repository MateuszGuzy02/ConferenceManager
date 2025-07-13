using Volo.Abp.Modularity;

namespace ConferenceManager;

public abstract class ConferenceManagerApplicationTestBase<TStartupModule> : ConferenceManagerTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
