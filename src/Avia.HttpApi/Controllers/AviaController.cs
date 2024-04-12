using Avia.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Avia.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class AviaController : AbpControllerBase
{
    protected AviaController()
    {
        LocalizationResource = typeof(AviaResource);
    }
}
