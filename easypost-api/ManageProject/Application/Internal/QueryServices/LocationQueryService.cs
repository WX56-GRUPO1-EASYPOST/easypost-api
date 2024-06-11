using easypost_api.ManageProject.Domain.Model.Entities;
using easypost_api.ManageProject.Domain.Model.Queries;
using easypost_api.ManageProject.Domain.Repositories;
using easypost_api.ManageProject.Domain.Services;

namespace easypost_api.ManageProject.Application.Internal.QueryServices;

public class LocationQueryService(ILocationRepository locationRepository): ILocationQueryService
{
    public async Task<Location?> Handle(GetLocationByIdQuery query)
    {
        return await locationRepository.FindByIdAsync(query.Id);
    }

    public async Task<IEnumerable<Location>> Handle(GetAllLocationsQuery query)
    {
        return await locationRepository.ListAsync();
    }
}