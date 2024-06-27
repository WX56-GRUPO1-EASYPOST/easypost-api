using easypost_api.IAM.Interfaces.ACL;

namespace easypost_api.Profiles.Application.Internal.OutboundServices.Services;

public class ExternalIamProfileService(IIamContextFacade iamContextFacade): IExternalIamProfileService
{
    public Task<bool> IsCompanyByUserId(int userId)
    {
        return iamContextFacade.UserExistsByUserId(userId);
    }
}