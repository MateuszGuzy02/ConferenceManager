using System;
using System.Collections.Generic;
using System.Text;
using ConferenceManager.Localization;
using Volo.Abp.Application.Services;

namespace ConferenceManager;

/* Inherit your application services from this class.
 */
public abstract class ConferenceManagerAppService : ApplicationService
{
    protected ConferenceManagerAppService()
    {
        LocalizationResource = typeof(ConferenceManagerResource);
    }
}
