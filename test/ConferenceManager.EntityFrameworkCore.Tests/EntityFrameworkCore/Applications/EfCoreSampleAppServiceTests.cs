using ConferenceManager.Samples;
using Xunit;

namespace ConferenceManager.EntityFrameworkCore.Applications;

[Collection(ConferenceManagerTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<ConferenceManagerEntityFrameworkCoreTestModule>
{

}
