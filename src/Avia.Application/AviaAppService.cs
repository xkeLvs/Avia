using System;
using System.Collections.Generic;
using System.Text;
using Avia.Localization;
using Volo.Abp.Application.Services;

namespace Avia;

/* Inherit your application services from this class.
 */
public abstract class AviaAppService : ApplicationService
{
    protected AviaAppService()
    {
        LocalizationResource = typeof(AviaResource);
    }
}
