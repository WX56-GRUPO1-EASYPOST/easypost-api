namespace easypost_api.Requests.Application.Internal.OutboundServices.ACL;

public interface IExternalRequestProfileService
{
    bool ProfileExists(int profileId);
    
}