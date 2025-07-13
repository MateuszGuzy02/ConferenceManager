using ConferenceManager.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace ConferenceManager.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(ConferenceManagerEntityFrameworkCoreModule),
    typeof(ConferenceManagerApplicationContractsModule)
    )]
public class ConferenceManagerDbMigratorModule : AbpModule
{
}
