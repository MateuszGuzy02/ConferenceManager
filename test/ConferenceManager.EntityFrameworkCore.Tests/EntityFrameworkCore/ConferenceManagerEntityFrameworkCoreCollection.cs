using Xunit;

namespace ConferenceManager.EntityFrameworkCore;

[CollectionDefinition(ConferenceManagerTestConsts.CollectionDefinitionName)]
public class ConferenceManagerEntityFrameworkCoreCollection : ICollectionFixture<ConferenceManagerEntityFrameworkCoreFixture>
{

}
