using ConferenceManager.Samples;
using Xunit;

namespace ConferenceManager.EntityFrameworkCore.Domains;

[Collection(ConferenceManagerTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<ConferenceManagerEntityFrameworkCoreTestModule>
{

}
