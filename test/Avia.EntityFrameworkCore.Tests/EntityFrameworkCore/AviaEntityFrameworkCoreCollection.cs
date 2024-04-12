using Xunit;

namespace Avia.EntityFrameworkCore;

[CollectionDefinition(AviaTestConsts.CollectionDefinitionName)]
public class AviaEntityFrameworkCoreCollection : ICollectionFixture<AviaEntityFrameworkCoreFixture>
{

}
