using easypost_api.ManageProject.Domain.Model.Commands;
using easypost_api.ManageProject.Domain.Model.Entities;
using easypost_api.ManageProject.Domain.Model.Queries;
using easypost_api.ManageProject.Domain.Services;

namespace easypost_api.ManageProject.Interfaces.ACL.Services;

public class LocationContextFacade(ILocationCommandService locationCommandService,
    ILocationQueryService locationQueryService): ILocationContextFacade
{
    public async Task<int?> CreateLocation(string department, string province, string district, string locality, string address,
        string reference)
    {
        var command = new CreateLocationCommand(department, province, district, locality, address, reference);
        var location = await locationCommandService.Handle(command);
        return location?.Id ?? 0;
    }

    public async Task<Location?> GetLocationById(int locationId)
    {
        var query = new GetLocationByIdQuery(locationId);
        var location = await locationQueryService.Handle(query);
        if (location == null)
        {
            return null;
        }

        return location;
    }
}