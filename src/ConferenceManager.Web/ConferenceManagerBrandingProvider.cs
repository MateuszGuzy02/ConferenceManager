using Microsoft.Extensions.Localization;
using ConferenceManager.Localization;
using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace ConferenceManager.Web;

[Dependency(ReplaceServices = true)]
public class ConferenceManagerBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<ConferenceManagerResource> _localizer;

    public ConferenceManagerBrandingProvider(IStringLocalizer<ConferenceManagerResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
