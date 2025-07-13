using ConferenceManager.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace ConferenceManager.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class ConferenceManagerController : AbpControllerBase
{
    protected ConferenceManagerController()
    {
        LocalizationResource = typeof(ConferenceManagerResource);
    }
}
