using Avia.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Avia.Permissions;

public class AviaPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(AviaPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(AviaPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<AviaResource>(name);
    }
}
