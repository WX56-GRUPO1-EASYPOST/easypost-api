namespace easypost_api.IAM.Application.Internal.OutboundServices.ACL;

public interface IExternalProfileService
{
    public Task<int> CreateProfile(
        string name,
        string description,
        string ruc,
        string phone,
        string email,
        string department,
        string district,
        string residential);
    
    public Task<int?> FetchProfileIdByEmail(string email);
}