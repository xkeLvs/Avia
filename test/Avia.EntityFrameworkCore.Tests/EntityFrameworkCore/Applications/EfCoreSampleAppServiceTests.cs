using Avia.Samples;
using Xunit;

namespace Avia.EntityFrameworkCore.Applications;

[Collection(AviaTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<AviaEntityFrameworkCoreTestModule>
{

}
