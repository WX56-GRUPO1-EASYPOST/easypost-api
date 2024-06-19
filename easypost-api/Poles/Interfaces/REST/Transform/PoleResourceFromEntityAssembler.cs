using easypost_api.Poles.Domain.Model.Aggregates;
using easypost_api.Poles.Interfaces.REST.Resources;

namespace easypost_api.Poles.Interfaces.REST.Transform;

public static class PoleResourceFromEntityAssembler
{
    public static PoleResource ToResourceFromEntity(Pole? entity)
    {
        return new PoleResource(
            entity.Id,
            entity.Description,
            entity.ProjectId,
            entity.GeoReferenceId,
            GeoReferenceResourceFromEntityAssembler.ToResourceFromEntity(entity.GeoReference)
        );
    }
}