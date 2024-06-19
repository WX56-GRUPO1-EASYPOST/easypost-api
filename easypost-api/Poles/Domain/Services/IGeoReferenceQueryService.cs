using easypost_api.Poles.Domain.Model.Entities;
using easypost_api.Poles.Domain.Model.Queries;

namespace easypost_api.Poles.Domain.Services;

public interface IGeoReferenceQueryService
{
    Task<IEnumerable<GeoReference?>> Handle(GetAllGeoReferencesQuery query);
    Task<GeoReference?> Handle(GetGeoReferenceByIdQuery query);
}