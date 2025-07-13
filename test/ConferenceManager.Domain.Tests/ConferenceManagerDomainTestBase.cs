using Volo.Abp.Modularity;

namespace ConferenceManager;

/* Inherit from this class for your domain layer tests. */
public abstract class ConferenceManagerDomainTestBase<TStartupModule> : ConferenceManagerTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
