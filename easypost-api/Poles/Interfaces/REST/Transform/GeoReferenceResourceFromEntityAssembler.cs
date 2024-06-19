using easypost_api.Poles.Domain.Model.Entities;
using easypost_api.Poles.Interfaces.REST.Resources;

namespace easypost_api.Poles.Interfaces.REST.Transform;

public static class GeoReferenceResourceFromEntityAssembler
{
    public static GeoReferenceResource ToResourceFromEntity(GeoReference entity)
    {
        return new GeoReferenceResource(
            entity.Id,
            entity.Latitude,
            entity.Longitude,
            entity.Description
        );
    }
}