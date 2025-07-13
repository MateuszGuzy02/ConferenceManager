using ConferenceManager.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace ConferenceManager.Permissions;

public class ConferenceManagerPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(ConferenceManagerPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(ConferenceManagerPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<ConferenceManagerResource>(name);
    }
}
