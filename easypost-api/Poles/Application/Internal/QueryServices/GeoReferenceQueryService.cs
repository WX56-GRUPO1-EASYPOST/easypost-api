using easypost_api.Poles.Domain.Model.Entities;
using easypost_api.Poles.Domain.Model.Queries;
using easypost_api.Poles.Domain.Repositories;
using easypost_api.Poles.Domain.Services;

namespace easypost_api.Poles.Application.Internal.QueryServices;

public class GeoReferenceQueryService(IGeoReferenceRepository geoReferenceRepository): IGeoReferenceQueryService
{
    public async Task<IEnumerable<GeoReference?>> Handle(GetAllGeoReferencesQuery query)
    {
        return await geoReferenceRepository.ListAsync();
    }

    public async Task<GeoReference?> Handle(GetGeoReferenceByIdQuery query)
    {
        return await geoReferenceRepository.FindByIdAsync(query.Id);
    }
}