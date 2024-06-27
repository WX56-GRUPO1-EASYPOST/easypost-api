namespace easypost_api.Profiles.Application.Internal.OutboundServices;

public interface IExternalIamService
{ 
    Task<bool> IsCompanyByUserId(int userId);
}