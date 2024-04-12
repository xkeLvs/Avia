using Volo.Abp.Settings;

namespace Avia.Settings;

public class AviaSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(AviaSettings.MySetting1));
    }
}
