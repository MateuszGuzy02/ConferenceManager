using ConferenceManager.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace ConferenceManager.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class ConferenceManagerPageModel : AbpPageModel
{
    protected ConferenceManagerPageModel()
    {
        LocalizationResourceType = typeof(ConferenceManagerResource);
    }
}
