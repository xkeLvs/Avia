using Avia.Samples;
using Xunit;

namespace Avia.EntityFrameworkCore.Domains;

[Collection(AviaTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<AviaEntityFrameworkCoreTestModule>
{

}
