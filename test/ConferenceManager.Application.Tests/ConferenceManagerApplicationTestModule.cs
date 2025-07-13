using Volo.Abp.Modularity;

namespace ConferenceManager;

[DependsOn(
    typeof(ConferenceManagerApplicationModule),
    typeof(ConferenceManagerDomainTestModule)
)]
public class ConferenceManagerApplicationTestModule : AbpModule
{

}
