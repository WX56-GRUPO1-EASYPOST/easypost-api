using easypost_api.Profiles.Interfaces.ACL;

namespace easypost_api.Requests.Application.Internal.OutboundServices.ACL.Services;

public class ExternalRequestProfileService(
    IProfilesContextFacade profilesContextFacade)
    :IExternalRequestProfileService
{
    public bool ProfileExists(int profileId)
    {
        return profilesContextFacade.ExistsProfileById(profileId);
    }
}