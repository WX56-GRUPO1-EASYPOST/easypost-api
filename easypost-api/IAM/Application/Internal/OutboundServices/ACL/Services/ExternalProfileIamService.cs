using easypost_api.Profiles.Interfaces.ACL;

namespace easypost_api.IAM.Application.Internal.OutboundServices.ACL.Services;

public class ExternalProfileIamService(IProfilesContextFacade profilesContextFacade): IExternalProfileIamService
{
    public async Task<int?> FetchProfileIdByEmail(string email)
    {
        var profileId = await profilesContextFacade.FetchProfileIdByEmail(email);
        if (profileId == 0) return await Task.FromResult<int?>(null);
        return profileId;
    }

    public async Task<int> CreateProfile(
        string name, 
        string description, 
        string ruc, 
        string phone, 
        string email, 
        string department, 
        string district, 
        string residential,
        string type
        )
    {
        var profileId = await profilesContextFacade.CreateProfileForUser(
            name, 
            description, 
            ruc, 
            phone, 
            email, 
            department, 
            district, 
            residential,
            type
            );
        if (profileId == 0) return await Task.FromResult<int>(0);
        return profileId;
    }
}