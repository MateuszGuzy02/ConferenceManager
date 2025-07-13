using Volo.Abp.Modularity;

namespace ConferenceManager;

[DependsOn(
    typeof(ConferenceManagerDomainModule),
    typeof(ConferenceManagerTestBaseModule)
)]
public class ConferenceManagerDomainTestModule : AbpModule
{

}
