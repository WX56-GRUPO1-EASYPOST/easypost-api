using easypost_api.IAM.Interfaces.ACL;

namespace easypost_api.Profiles.Application.Internal.OutboundServices.Services;

public class ExternalIamService(IIamContextFacade iamContextFacade): IExternalIamService
{
    public Task<bool> IsCompanyByUserId(int userId)
    {
        return iamContextFacade.UserExistsByUserId(userId);
    }
}