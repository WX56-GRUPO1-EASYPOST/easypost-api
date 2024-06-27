namespace easypost_api.Requests.Application.Internal.OutboundServices.ACL;

public interface IExternalRequestLocationService
{
    Task<int?> CreateLocation(
        string department,
        string province,
        string district,
        string locality,
        string address,
        string reference);
}