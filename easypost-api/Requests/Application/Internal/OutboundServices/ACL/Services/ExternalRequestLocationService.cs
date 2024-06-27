using easypost_api.ManageProject.Interfaces.ACL;

namespace easypost_api.Requests.Application.Internal.OutboundServices.ACL.Services;

public class ExternalRequestLocationService(
    ILocationContextFacade locationContextFacade)
    : IExternalRequestLocationService
{
    public async Task<int?> CreateLocation(string department, string province, string district, string locality, string address,
        string reference)
    {
        var locationId = await locationContextFacade.CreateLocation(department, province, district, locality, address,
            reference);
        return locationId;
    }
}