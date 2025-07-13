using Volo.Abp.Settings;

namespace ConferenceManager.Settings;

public class ConferenceManagerSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(ConferenceManagerSettings.MySetting1));
    }
}
