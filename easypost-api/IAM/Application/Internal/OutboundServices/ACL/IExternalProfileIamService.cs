namespace easypost_api.IAM.Application.Internal.OutboundServices.ACL;

public interface IExternalProfileIamService
{
    public Task<int> CreateProfile(
        string name,
        string description,
        string ruc,
        string phone,
        string email,
        string department,
        string district,
        string residential,
        string type
        );
    
    public Task<int?> FetchProfileIdByEmail(string email);
}