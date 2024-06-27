namespace easypost_api.Profiles.Application.Internal.OutboundServices;

public interface IExternalIamProfileService
{ 
    Task<bool> IsCompanyByUserId(int userId);
}